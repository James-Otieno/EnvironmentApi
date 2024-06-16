namespace MonitoringAPI.Models
{
    public class MonitoringData
    {

        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public float Temperature { get; set; }
        public float Rainfall { get; set; }
        public float Humidity { get; set; }

        public Guid StationId { get; set; }
        public MonitoringStation ? Station { get; set; }

    }
}
