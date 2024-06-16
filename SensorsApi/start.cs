using Microsoft.AspNetCore.Hosting;
using SeensorsMicroService.Application.Services;
using SensorsApi.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SensorsApi
{

        public class start
        {
            public static void Main(string[] args)
            {
                CreateHostBuilder(args).Build().Run();
            }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    //Register services
                  
                    //services.AddSingleton<ITemperatureService, TemperatureService>();
                    //services.AddSingleton<IRainfallService, RainfallService>();
                    //services.AddSingleton<IHumidityService, HumidityService>();
                    //services.AddSingleton<IAirPollutionService, AirPollutionService>();
                    //services.AddSingleton<ICO2EmissionsService, CO2EmissionsService>();

                    // Other configurations...
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<start>();
                });
        }
    }
    

}

