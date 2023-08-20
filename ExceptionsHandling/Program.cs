using ExceptionsHandling.Exception;
using ExceptionsHandling.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//Read App settings

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true);


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MarketDbContext>(
       options => options.UseSqlServer(builder.Configuration.GetConnectionString("Analytics")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureCustomExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
