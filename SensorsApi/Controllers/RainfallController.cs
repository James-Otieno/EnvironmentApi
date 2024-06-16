using Microsoft.AspNetCore.Mvc;
using SeensorsMicroService.Application.Dtos;
using SeensorsMicroService.Application.Services;
using SeensorsMicroService.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SensorsApi.Controllers
{
    [ApiController]
    [Route("api/rainfall")]
    public class RainfallController : ControllerBase
    {
        private readonly IRainfallService rainfallService;

        public RainfallController(IRainfallService rainfallService)
        {
            this.rainfallService = rainfallService ?? throw new ArgumentNullException(nameof(rainfallService));
        }

        [HttpPost]
        public IActionResult AddRainfallData([FromBody] RainfallDto data)
        {
            try
            {
                rainfallService.AddNewRainfallData(data);
                return Ok("Rainfall data added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAllRainfallData()
        {
            try
            {
                var allData = rainfallService.GetAllData();
                return Ok(allData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("range")]
        public IActionResult GetRainfallDataInRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var dataInRange = rainfallService.GetDataInRange(startDate, endDate);
                return Ok(dataInRange);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }

    public interface IRainfallService
    {
        void AddNewRainfallData(RainfallDto data);
        IEnumerable<RainfallDto> GetAllData();
        IEnumerable<RainfallDto> GetDataInRange(DateTime startDate, DateTime endDate);
    }
}
