using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain;

public class AppDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Receptionist> Receptionists { get; set; }

    public AppDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public override Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State is not EntityState.Deleted ||
                entry.Entity is not BaseEntity)
                continue;

            entry.State = EntityState.Modified;
            (entry.Entity as BaseEntity)!.IsDeleted = true;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
