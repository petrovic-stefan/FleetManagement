using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class FleetDbContext : DbContext
{
    public FleetDbContext(DbContextOptions<FleetDbContext> options) : base(options) { }

    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<Driver> Drivers => Set<Driver>();
    public DbSet<Maintenance> Maintenance => Set<Maintenance>();
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<Assignment> Assignments => Set<Assignment>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Vehicle>(e =>
        {
            e.Property(x => x.PlateNumber).IsRequired().HasMaxLength(32);
            e.HasIndex(x => x.PlateNumber).IsUnique();
            e.Property(x => x.Make).IsRequired().HasMaxLength(64);
            e.Property(x => x.Model).IsRequired().HasMaxLength(64);
        });

        b.Entity<Driver>(e =>
        {
            e.Property(x => x.FullName).IsRequired().HasMaxLength(128);
            e.Property(x => x.LicenseNumber).IsRequired().HasMaxLength(64);
        });

        b.Entity<Maintenance>(e =>
        {
            e.HasOne(x => x.Vehicle)
             .WithMany(v => v.Maintenance)
             .HasForeignKey(x => x.VehicleId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        b.Entity<Expense>(e =>
        {
            e.HasOne(x => x.Vehicle)
             .WithMany(v => v.Expenses)
             .HasForeignKey(x => x.VehicleId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        b.Entity<Assignment>(e =>
        {
            e.HasOne(x => x.Vehicle)
             .WithMany(v => v.Assignments)
             .HasForeignKey(x => x.VehicleId);

            e.HasOne(x => x.Driver)
             .WithMany(d => d.Assignments)
             .HasForeignKey(x => x.DriverId);
        });
    }
}