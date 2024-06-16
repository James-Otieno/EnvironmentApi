namespace MonitoringAPI.Models
{
    public class MonitoringStation
    {
        public Guid Id{ get; set; }
        public string ? Name { get; set; }
        public ICollection<MonitoringData> ? Data { get; set; }

    }
}
