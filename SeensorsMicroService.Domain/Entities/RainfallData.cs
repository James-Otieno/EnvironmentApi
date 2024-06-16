using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeensorsMicroService.Domain.Entities
{
    public class RainfallData
    {
        public double Temperature { get; set; }
        public DateTime Timestamp { get; set; }

        public string Location { get; set; } 
        public string Unit { get; set; } 
        public string Source { get; set; }



        public RainfallData(double temperature, DateTime timestamp,string location,string unit,string source)
        {
            Temperature = temperature;
            Timestamp = timestamp;
            Location = location;
            Unit = unit;
            Source = source;

        }


        public RainfallData AddNewRainfallData(double temperature, DateTime timestamp, string location, string unit, string source)
        {
            return new RainfallData(Temperature, timestamp,location,unit, source);
        }



    }
}

