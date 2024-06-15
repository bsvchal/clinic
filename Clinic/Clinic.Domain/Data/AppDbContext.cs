using Microsoft.EntityFrameworkCore;
using Clinic.Domain.Entities;
using Clinic.Domain.EntityConfigurations;

namespace Clinic.Domain.Data;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new AccountEntityTypeConfiguration())
            .ApplyConfiguration(new AppointmentEntityTypeConfiguration())
            .ApplyConfiguration(new DoctorEntityTypeConfiguration())
            .ApplyConfiguration(new OfficeEntityTypeConfiguration())
            .ApplyConfiguration(new PatientEntityTypeConfiguration())
            .ApplyConfiguration(new PhotoEntityTypeConfiguration())
            .ApplyConfiguration(new ReceptionistEntityTypeConfiguration());
    }
}
