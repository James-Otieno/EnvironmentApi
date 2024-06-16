using Microsoft.AspNetCore.Mvc;
using MonitoringAPI.Models;
using MonitoringAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonitoringAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitoringStationController :Controller
    {
        private readonly IMonitoringStationRepository _repository;

        public MonitoringStationController(IMonitoringStationRepository repository)
        {
            _repository = repository;
           
        }


        [HttpGet]
        public async Task<IActionResult> GetStations()
        {
            var stations = await _repository.GetStationsAsync();
            return Ok(stations);
        }

       
        [HttpPost]
        public async Task<IActionResult> AddStation([FromBody] MonitoringStation station)
        {
            var addedId = await _repository.AddStationAsync(station);
            return Ok(addedId);
        }

    }

}
