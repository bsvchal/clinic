using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Domain.EntityConfigurations;

public class DoctorEntityTypeConfiguration
    : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(d => d.Id);

        builder
            .HasOne(d => d.Office)
            .WithMany(o => o.Doctors);

        builder
            .HasOne(d => d.Account);

        builder
            .HasMany(d => d.Appointments)
            .WithOne(a => a.Doctor)
            .HasForeignKey(a => a.DoctorId);

        builder
            .Property(d => d.FirstName).IsRequired();
        builder
            .Property(d => d.LastName).IsRequired();
        builder
            .Property(d => d.MiddleName).IsRequired();
        builder
            .Property(d => d.Specialization).IsRequired();
        builder
            .Property(d => d.Office).IsRequired();
        builder
            .Property(d => d.Account).IsRequired();
        builder
            .Property(d => d.Appointments).IsRequired();
    }
}
