using final_proyect.Interfaces;
using final_proyect.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using simple_to_do.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration; // Obtener la configuración

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registro de ToDoDbContext con SQLite
builder.Services.AddDbContext<ToDoDbContext>(options =>
    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

// Registro de IUserService y su implementación UserService
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
