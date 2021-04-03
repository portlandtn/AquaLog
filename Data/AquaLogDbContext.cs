using AquaLog.Core;
using Microsoft.EntityFrameworkCore;

namespace AquaLog.Data
{
    public class AquaLogDbContext : DbContext
    {
        public DbSet<Aquarium> Aquariums { get; set; }
        public DbSet<MeasurementKey> MeasurementKeys { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Measurement> Measurements { get; set; }

        public AquaLogDbContext(DbContextOptions<AquaLogDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}