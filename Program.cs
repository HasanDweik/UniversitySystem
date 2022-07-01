using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Helpers;
using UniversitySystem.Interfaces;
using UniversitySystem.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registration
builder.Services.AddScoped(typeof(IStudentHelper), typeof(StudentHelpers));
builder.Services.AddScoped(typeof(IUploadFileHelper), typeof(UploadFileHelper));
builder.Services.AddScoped(typeof(IDateTimeHelper), typeof(DateTimeHelper));
builder.Services.AddScoped(typeof(IRoleHelper), typeof(RoleHelper));
builder.Services.AddDbContext<InmindContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=Inmind;Username=postgres;Password=123456"));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
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