using Microsoft.EntityFrameworkCore;
using MonitoringAPI.Models;

namespace MonitoringAPI.Repositories
{
    public class MonitoringDataRepository:IMonitoringDataRepository
    {

        private readonly ApplicationDbContext _dbContext;
        public MonitoringDataRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        public async Task<IEnumerable<MonitoringData>> GetMonitoringDataByStationIdAsync(Guid stationId)
        {
            return await _dbContext.MonitoringData.Where(d => d.StationId == stationId).ToListAsync();
        }
        public async Task AddDataAsync(Guid stationId, MonitoringData newData)
        {
            var station = await _dbContext.MonitoringStations.FindAsync(stationId);
            if (station == null)
            {
                throw new ArgumentException("Station not found.");
            }

            newData.StationId = stationId;
            _dbContext.MonitoringData.Add(newData);
            await _dbContext.SaveChangesAsync();
        }

    }
}
