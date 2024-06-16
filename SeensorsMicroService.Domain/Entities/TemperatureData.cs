using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeensorsMicroService.Domain.Entities
{
    public class TemperatureData
    {
        public double Temperature { get; set; }
        public DateTime Timestamp { get; set; }
        public string Location { get; set; }
        public string Unit { get; set; }
        public string Source { get; set; }

        public TemperatureData(double temperature, DateTime timestamp, string location, string unit, string source)
        {

        }

        public TemperatureData AddNewTemperatureData(double temperature, DateTime timestamp, string location, string unit, string source)
        {
            return new TemperatureData(Temperature, timestamp, location, unit, source);
        }
    }
}
