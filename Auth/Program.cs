using Auth.Infrastructure;
using Auth.Application.Interfaces;
using Auth.Application.UseCases;
using Auth.Data.Repositories;
using Auth.Infrastructure.TokenService;
using Auth.Infrastructure.PasswordHashing;

var builder = WebApplication.CreateBuilder(args);

// Add AuthContext to DI
builder.Services.AddDbContext<AuthContext>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<LoginUserUseCase>();
builder.Services.AddScoped<RegisterUserUseCase>();
builder.Services.AddScoped<RefreshRouteUseCase>();
builder.Services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();

var app = builder.Build();

// Middleware
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();