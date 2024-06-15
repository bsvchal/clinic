using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Domain.EntityConfigurations;

public class AppointmentEntityTypeConfiguration
    : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(a => a.Id);

        builder
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments);

        builder
            .HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments);

        builder
            .Property(a => a.Price)
            .HasPrecision(10, 3);
    }
}
