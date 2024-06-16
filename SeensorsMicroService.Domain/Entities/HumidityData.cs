using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeensorsMicroService.Domain.Entities
{
    public class HumidityData
    {
        public double Humidity { get; set; }
        public DateTime Timestamp { get; set; }
        public string Location { get; set; } 
        public string Unit { get; set; } 
        public string Source { get; set; }

        public HumidityData(double humidity, DateTime timestamp, string location, string unit, string source)
        {
            Humidity = humidity;
            Timestamp = timestamp;
            Location = location;
            Unit = unit;
            Source = source;
                
        }

        public HumidityData  AddNewHumidityData  (double humidity, DateTime timestamp, string location, string unit, string source)
        {
            return new HumidityData( humidity,timestamp, location,unit, source); 
        }
    }
}
