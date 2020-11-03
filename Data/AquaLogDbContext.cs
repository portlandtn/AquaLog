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
            modelBuilder.Entity<MeasurementKey>(entity =>
            {
                entity.HasOne(mk => mk.Measurement)
                     .WithMany(m => m.MeasurementKeys)
                     .OnDelete(DeleteBehavior.NoAction);

                entity.HasKey(mk => mk.Id);
            });

            modelBuilder.Entity<Aquarium>(entity =>
            {
                entity.HasMany(a => a.Measurements)
                    .WithOne(m => m.Aquarium)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasKey(a => a.Id);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasOne(l => l.Measurement)
                    .WithOne(m => m.Log)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasKey(l => l.Id);
            });

            modelBuilder.Entity<Measurement>(entity =>
            {
                entity.HasOne(m => m.Aquarium)
                    .WithMany(a => a.Measurements)
                    .HasForeignKey(a => a.AquariumId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Measurement_Aquarium");

                entity.HasMany(mk => mk.MeasurementKeys)
                    .WithOne(m => m.Measurement)
                    .HasForeignKey(mk => mk.Id)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Measurement_MeasurementKey");

                entity.HasOne(l => l.Log)
                    .WithOne(m => m.Measurement)
                    .HasForeignKey<Measurement>(m => m.Id)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Measurement_Log");

                entity.HasIndex(m => new { m.AquariumId, m.MeasurementKeyId, m.LogId }).IsUnique();

                entity.HasKey(m => m.Id);
            });
        }
    }
}