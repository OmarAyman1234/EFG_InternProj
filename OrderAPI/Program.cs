using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OrderAPI.Infrastructure.Context;
using OrderAPI.Infrastructure.Repositories;
using Serilog;
using System.Text;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Register Serilog with the builder
builder.Host.UseSerilog();

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-$ecret_KEY-for-making__JWT--token")),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddScoped<OrderContext>();
// builder.Services.AddScoped<OrderServices>(); // Remove old service registration
builder.Services.AddScoped<OrderAPI.Application.UseCases.OrderUseCase.GetAllOrdersUseCase>();
builder.Services.AddScoped<OrderAPI.Application.UseCases.OrderUseCase.GetOrderByIdUseCase>();
builder.Services.AddScoped<OrderAPI.Application.UseCases.OrderUseCase.CreateOrderUseCase>();
builder.Services.AddScoped<OrderAPI.Application.UseCases.OrderUseCase.EditOrderUseCase>();
builder.Services.AddScoped<OrderAPI.Application.UseCases.OrderUseCase.DeleteOrderUseCase>();
builder.Services.AddScoped<OrderAPI.Application.UseCases.OrderUseCase.OrderService>();
builder.Services.AddScoped<OrderAPI.Application.Interfaces.IOrderRepository, OrderAPI.Infrastructure.Repositories.OrderRepository>();

// Product services injection
builder.Services.AddScoped<OrderAPI.Application.UseCases.ProductUseCase.GetAllProductsUseCase>();
builder.Services.AddScoped<OrderAPI.Application.UseCases.ProductUseCase.ProductService>();
builder.Services.AddScoped<OrderAPI.Application.Interfaces.IProductRepository,  ProductRepository>();

// Register infrastructure implementations
builder.Services.AddScoped<OrderAPI.Application.Interfaces.ICachingService, OrderAPI.Infrastructure.Services.RedisService>();
builder.Services.AddScoped<OrderAPI.Application.Interfaces.IMessageBroker, OrderAPI.Infrastructure.Services.RabbitMQService>();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "EFGIntern_";
});

builder.Services.AddAuthorization();
builder.Services.AddSingleton<RabbitMQ.Client.ConnectionFactory>(sp =>
{
    // You can load these from configuration if needed
    return new RabbitMQ.Client.ConnectionFactory
    {
        HostName = "localhost"
        // Add more settings as needed (UserName, Password, etc.)
    };
});
var app = builder.Build();

// Middleware
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add username to log context
app.Use(async (context, next) =>
{
    var username = context.Request.Headers["X-Username"].FirstOrDefault();
    if (!string.IsNullOrEmpty(username))
    {
        Serilog.Context.LogContext.PushProperty("Username", username);
    }
    await next();
});

app.UseSerilogRequestLogging();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();