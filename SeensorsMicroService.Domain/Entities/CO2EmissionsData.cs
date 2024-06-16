using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeensorsMicroService.Domain.Entities
{
    public class CO2EmissionsData
    {
        public double CO2Emissions { get; set; }
        public DateTime Timestamp { get; set; }
        public string Location { get; set; } 
        public string Unit { get; set; } 
        public string Source { get; set; }

        public CO2EmissionsData(double co2Emissions, DateTime timestamp, string location, string unit, string source)
        {
            CO2Emissions = co2Emissions;
            Timestamp = timestamp;
            Location = location;
            Unit = unit;
            Source = source;


        }
        public CO2EmissionsData()
        {
                
        }


        public static CO2EmissionsData AddNewCO2EmissionsData(double co2Emissions, DateTime timestamp, string location, string unit, string source)
        {
            return new CO2EmissionsData(co2Emissions, timestamp, location, unit, source);


        }

    }

}
