using Microsoft.AspNetCore.Mvc;
using SeensorsMicroService.Application.Dtos;
using SeensorsMicroService.Application.Services;
using SeensorsMicroService.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SensorsApi.Controllers
{
    [ApiController]
    [Route("api/airpollution")]
    public class AirPollutionController : ControllerBase
    {
        private readonly IAirPollutionService airPollutionService;

        public AirPollutionController(IAirPollutionService airPollutionService)
        {
            this.airPollutionService = airPollutionService ?? throw new ArgumentNullException(nameof(airPollutionService));
        }

        [HttpPost]
        public IActionResult AddAirPollutionData([FromBody] AirDto data)
        {
            try
            {
                airPollutionService.AddNewAirPollutionData(data);
                return Ok("Air pollution data added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAllAirPollutionData()
        {
            try
            {
                var allData = airPollutionService.GetAllData();
                return Ok(allData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("range")]
        public IActionResult GetAirPollutionDataInRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var dataInRange = airPollutionService.GetDataInRange(startDate, endDate);
                return Ok(dataInRange);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }

    public interface IAirPollutionService
    {
         public void AddNewAirPollutionData(AirDto data);
        IEnumerable<AirDto> GetAllData();
        IEnumerable<AirDto> GetDataInRange(DateTime startDate, DateTime endDate);
    }
}
