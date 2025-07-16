using Auth.Data.Context;
using Auth.Data.Repositories;
using Auth.Utils.TokenService;

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