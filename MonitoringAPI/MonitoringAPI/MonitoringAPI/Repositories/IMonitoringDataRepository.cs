
using MonitoringAPI.Models;

namespace MonitoringAPI.Repositories
{
    public interface IMonitoringDataRepository
    {
        Task<IEnumerable<MonitoringData>> GetMonitoringDataByStationIdAsync(Guid stationId);
        Task AddDataAsync(Guid stationId, MonitoringData newData);

    }
}
