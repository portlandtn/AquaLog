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
            modelBuilder.Entity<Measurement>(entity =>
            {
                entity.HasOne(a => a.Aquarium)
                    .WithMany(m => m.Measurement)
                    .HasForeignKey(a => a.AquariumId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Measurement_Aquarium");

                entity.HasOne(mk => mk.MeasurementKey)
                    .WithMany(m => m.Measurement)
                    .HasForeignKey(mk => mk.MeasurementKeyId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Measurement_MeasurementKey");

                entity.HasOne(l => l.Log)
                    .WithMany(m => m.Measurement)
                    .HasForeignKey(l => l.LogId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Measurement_Log");

                entity.HasKey(m => new { m.AquariumId, m.MeasurementKeyId, m.LogId });
            });
        }
    }
}