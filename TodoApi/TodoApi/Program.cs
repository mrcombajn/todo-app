using Microsoft.EntityFrameworkCore;
using TodoApi.Controllers;
using TodoApi.Database;

var builder = WebApplication.CreateBuilder(args);
var connctionString = builder.Configuration.GetConnectionString("default");

builder.Services.AddSingleton<WeatherForecastController>();

// Add services to the container.
builder.Services.AddDbContext<TodoContext>(db => db.UseNpgsql(connctionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/", (WeatherForecastController weatherForecastController) => weatherForecastController.Get());

app.MapControllers();

app.Run();
