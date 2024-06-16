using Microsoft.EntityFrameworkCore;
using MonitoringAPI.Models;
using MonitoringAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));



// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IMonitoringStationRepository, MonitoringStationRepository>();
builder.Services.AddScoped<IMonitoringDataRepository, MonitoringDataRepository>();
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

app.MapControllers();

app.Run();
