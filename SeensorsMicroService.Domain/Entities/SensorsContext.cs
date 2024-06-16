using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeensorsMicroService.Domain.Entities
{
   public  class SensorsContext:DbContext
    {
        public DbSet<RainfallData> RAINFALL { get; set; }
        public DbSet<TemperatureData> temperatureData { get; set; }
        public DbSet<HumidityData> HUMIDITY{ get; set; }
        public DbSet<AirPollutionData> AIR { get; set; }
        public DbSet<CO2EmissionsData> CO2{ get; set; }

        public SensorsContext(DbContextOptions<SensorsContext> opt) : base(opt) 
        
        {

            //try
            //{
            //    //var dbCreator = Database.GetService<IDatabaseCreator>()
            //    //    as RelationalDatabaseCreator;
            //    //if (dbCreator != null)
            //    //{
            //    //    if (!dbCreator.CanConnect()) dbCreator.Create();
            //    //    if (!dbCreator.HasTables()) dbCreator.CreateTables();
            //    //}

            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }


    }

}
