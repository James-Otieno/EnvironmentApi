using MonitoringAPI.Models;

namespace MonitoringAPI.Repositories
{
    public interface IMonitoringStationRepository
    {
        Task<IEnumerable<MonitoringStation>> GetStationsAsync();
        Task<Guid> AddStationAsync(MonitoringStation station);
    }


}
