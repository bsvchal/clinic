using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Domain.EntityConfigurations;

public class PatientEntityTypeConfiguration
    : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.Account);

        builder
            .HasMany(p => p.Appointments)
            .WithOne(a => a.Patient)
            .HasForeignKey(a => a.PatientId);

        builder
            .Property(p => p.FirstName).IsRequired();
        builder
            .Property(p => p.LastName).IsRequired();
        builder
            .Property(p => p.MiddleName).IsRequired();
        builder
            .Property(p =>  p.Account).IsRequired();
        builder
            .Property(p => p.Appointments).IsRequired();
    }
}
