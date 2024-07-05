using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain;

public class ClinicDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Receptionist> Receptionists { get; set; }

    public ClinicDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .OnDelete(DeleteBehavior.NoAction);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var now = DateTime.UtcNow;
        var entries = ChangeTracker.Entries().ToList();
        foreach (var entry in entries)
        {
            if (entry.State is not EntityState.Deleted ||
                entry.Entity is not BaseEntity)
                continue;

            entry.State = EntityState.Modified;
            (entry.Entity as BaseEntity)!.DeletedTime = now;
            (entry.Entity as BaseEntity)!.IsDeleted = true;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
