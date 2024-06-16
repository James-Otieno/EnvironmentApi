using Microsoft.EntityFrameworkCore;
using MonitoringAPI.Models;

namespace MonitoringAPI.Repositories
{
    public class MonitoringStationRepository : IMonitoringStationRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public MonitoringStationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        public async Task<IEnumerable<MonitoringStation>> GetStationsAsync()
        {
            return await _dbContext.MonitoringStations.ToListAsync();
        }

      
        public async Task<Guid> AddStationAsync(MonitoringStation station)
        {
            _dbContext.MonitoringStations.Add(station);
            await _dbContext.SaveChangesAsync();
            return station.Id;
        }

    }
}

