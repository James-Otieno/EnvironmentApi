using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeensorsMicroService.Domain.Entities
{
   public class AirPollutionData
    {
        public double AirPollution { get; set; }
        public DateTime Timestamp { get; set; }
        public string Location { get; set; } 
        public string Unit { get; set; } 
        public string Source { get; set; }

        public AirPollutionData(double airPollution, DateTime timestamp, string location, string unit, string source)
        {
            AirPollution = airPollution;
            Timestamp = timestamp;
            Location = location;
            Unit = unit;
            Source = source;
                
        }
        public AirPollutionData  AddNewAirPollutionData(double airPollution, DateTime timestamp, string location, string unit, string source)
        {
            return new AirPollutionData(airPollution, timestamp, location, unit, source);
        }
    }
}
