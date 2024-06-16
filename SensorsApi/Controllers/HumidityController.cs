using Microsoft.AspNetCore.Mvc;
using SeensorsMicroService.Application.Dtos;
using SeensorsMicroService.Application.Services;
using SeensorsMicroService.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SensorsApi.Controllers
{
    [ApiController]
    [Route("api/humidity")]
    public class HumidityController : ControllerBase
    {
        private readonly IHumidityService humidityService;

        public HumidityController(IHumidityService humidityService)
        {
            this.humidityService = humidityService ?? throw new ArgumentNullException(nameof(humidityService));
        }

        [HttpPost]
        public IActionResult AddHumidityData([FromBody] HumidityDto data)
        {
            try
            {
                humidityService.AddNewHumidityData(data);
                return Ok("Humidity data added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAllHumidityData()
        {
            try
            {
                var allData = humidityService.GetAllData();
                return Ok(allData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("range")]
        public IActionResult GetHumidityDataInRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var dataInRange = humidityService.GetDataInRange(startDate, endDate);
                return Ok(dataInRange);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }

    public interface IHumidityService
    {
        void AddNewHumidityData(HumidityDto data);
        IEnumerable<HumidityDto> GetAllData();
        IEnumerable<HumidityDto> GetDataInRange(DateTime startDate, DateTime endDate);
    }
}
