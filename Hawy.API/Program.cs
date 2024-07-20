using Hawy.Infrastructure.JwtProvider;
using Hawy.Infrastructure.PasswordHasher;
using Hawy.Persistence;
using Hawy.Persistence.Interfaces;
using Hawy.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var config = builder.Configuration;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<HawyDbContext>(
    options =>
    {
        options.UseNpgsql(config.GetConnectionString(nameof(HawyDbContext)));
    });

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddAuthentication();
services.AddAuthorization();
services.AddControllers();

services.AddScoped<IPasswordHasher, PasswordHasher>();
services.AddScoped<IJwtProvider, JwtProvider>();
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IProductRepository, ProductRepository>();
services.AddScoped<ICategoryRepository, CategoryRepository>();

services.Configure<JwtOptions>(config.GetSection(nameof(JwtOptions)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
