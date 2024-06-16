using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeensorsMicroService.Application.Dtos
{
    public record  CO2Dto
    {
        public double CO2Emissions { get; set; }
        public DateTime Timestamp { get; set; }
        public string Location { get; set; }
        public string Unit { get; set; }
        public string Source { get; set; }
    }
}
