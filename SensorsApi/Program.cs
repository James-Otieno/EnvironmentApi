using Microsoft.EntityFrameworkCore;
using SeensorsMicroService.Application.Services;
using SeensorsMicroService.Domain.Entities;
using SensorsApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("SENSORDATA");
builder.Services.AddDbContext<SensorsContext>(opt =>
opt.UseSqlServer(connectionString));




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddControllers();
//builder.Services.AddScoped<ITemperatureService, TemperatureService>();
//builder.Services.AddScoped<ITemperatureRepository, TemperatureRepository>();
//builder.Services.AddScoped<IRainfallService, RainfallService>();
//builder.Services.AddScoped<IRainfallRepository, RainfallRepository>();
//builder.Services.AddScoped<IHumidityService, HumidityService>();
//builder.Services.AddScoped<IAirPollutionService, AirPollutionService>();
//builder.Services.AddScoped<ICO2EmissionsService, CO2EmissionsService>();








var app = builder.Build();
//using (var serviceScope = app.Services.CreateScope())
//{
//    var dbcontext = serviceScope.ServiceProvider.GetRequiredService<SensorsContext>();
//    dbcontext.Database.Migrate();
//}
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
