using System;
using System.Linq;
using Cinema.Backend.Providers;
using Cinema.Backend.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();

builder.Services.AddTransient<CinemaProvider>();
builder.Services.AddTransient<CinemaService>();
builder.Services.AddTransient<HomeService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

//builder.Services.AddDbContext<DatabaseContext>();
//
//
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options =>
//     {
//         options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//         {
//             ValidateIssuer = true,
//             ValidateAudience = true,
//             ValidateLifetime = true,
//             ValidateIssuerSigningKey = true,
//             ValidIssuer = "yourIssuer", // Заменить на твой issuer
//             ValidAudience = "yourAudience", // Заменить на твой audience
//             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//         };
//     });


var app = builder.Build();

app.UseCors(builder =>
        builder
            .AllowAnyOrigin() // Позволяет доступ с любого домена
            .AllowAnyMethod() // Позволяет все HTTP-методы (GET, POST и т.д.)
            .AllowAnyHeader() // Позволяет любые заголовки
);

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();