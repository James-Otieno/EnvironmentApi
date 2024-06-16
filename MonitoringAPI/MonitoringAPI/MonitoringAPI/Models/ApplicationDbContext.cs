using Microsoft.EntityFrameworkCore;

namespace MonitoringAPI.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        
        }
        public DbSet<MonitoringStation> MonitoringStations { get; set; }
        public DbSet<MonitoringData> MonitoringData { get; set; }
      
    }
}

