using Clinic.Domain.Entities;
using Clinic.Domain.Interceptors;
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new SoftDeleteInterceptor());
    }
}
