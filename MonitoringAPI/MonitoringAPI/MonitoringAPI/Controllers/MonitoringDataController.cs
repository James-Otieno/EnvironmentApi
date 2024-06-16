using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonitoringAPI.Models;
using MonitoringAPI.Repositories;

namespace MonitoringAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitoringDataController : Controller
    {
        private readonly IMonitoringDataRepository _monitoringDataRepository;
        public MonitoringDataController(IMonitoringDataRepository monitoringDataRepository)
        {
            _monitoringDataRepository = monitoringDataRepository;
            
        }
        [HttpGet("{stationId}")]
        public async Task<IActionResult> GetMonitoringDataByStationId(Guid stationId)
        {
            var data = await _monitoringDataRepository.GetMonitoringDataByStationIdAsync(stationId);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        [Route("{stationId}")]
        public async Task<IActionResult> AddData(Guid stationId, [FromBody] MonitoringData newData)
        {
            await _monitoringDataRepository.AddDataAsync(stationId, newData);
            return Ok();
        }

    }
}
