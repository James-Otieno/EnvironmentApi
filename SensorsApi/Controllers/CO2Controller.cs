using Microsoft.AspNetCore.Mvc;
using SeensorsMicroService.Application.Dtos;
using SeensorsMicroService.Application.Services;
using SeensorsMicroService.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SensorsApi.Controllers
{
    [ApiController]
    [Route("api/co2")]
    public class CO2EmissionsController : ControllerBase
    {
        private readonly ICO2EmissionsService co2EmissionsService;

        public CO2EmissionsController(ICO2EmissionsService co2EmissionsService)
        {
            this.co2EmissionsService = co2EmissionsService ?? throw new ArgumentNullException(nameof(co2EmissionsService));
        }

        [HttpPost]
        public IActionResult AddCO2EmissionsData([FromBody] CO2Dto data)
        {
            try
            {
                co2EmissionsService.AddNewCO2EmissionsData(data);
                return Ok("CO2 emissions data added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAllCO2EmissionsData()
        {
            try
            {
                var allData = co2EmissionsService.GetAllData();
                return Ok(allData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("range")]
        public IActionResult GetCO2EmissionsDataInRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var dataInRange = co2EmissionsService.GetDataInRange(startDate, endDate);
                return Ok(dataInRange);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }

    public interface ICO2EmissionsService
    {
        public void AddNewCO2EmissionsData(CO2Dto data);
        IEnumerable<CO2Dto> GetAllData();
        IEnumerable<CO2Dto> GetDataInRange(DateTime startDate, DateTime endDate);
    }
}
