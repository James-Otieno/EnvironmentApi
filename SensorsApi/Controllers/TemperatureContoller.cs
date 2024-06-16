using Microsoft.AspNetCore.Mvc;
using SeensorsMicroService.Application.Dtos;
using SeensorsMicroService.Application.Services;
using SeensorsMicroService.Domain.Entities;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SensorsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureContoller : ControllerBase
    {
        public class TemperatureController : ControllerBase
        {
            private readonly ITemperatureService temperatureService;

            public TemperatureController(ITemperatureService temperatureService)
            {
                this.temperatureService = temperatureService;
            }

            [HttpPost]
            public IActionResult AddTemperatureData([FromBody] TemperatureDto data)
            {
                try
                {
                    temperatureService.AddNewTemperatureData(data);
                    return Ok("Temperature data added successfully.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }

            [HttpGet]
            public IActionResult GetAllTemperatureData()
            {
                try
                {
                    var allData = temperatureService.GetAllData();
                    return Ok(allData);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
        }
    }

    public interface ITemperatureService
    {
        void AddNewTemperatureData(TemperatureDto data);
        IEnumerable<TemperatureDto> GetAllData();
        IEnumerable<TemperatureDto> GetDataInRange(DateTime startDate, DateTime endDate);
    }
}