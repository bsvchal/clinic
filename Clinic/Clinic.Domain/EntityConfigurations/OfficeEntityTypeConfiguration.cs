using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Domain.EntityConfigurations;

public class OfficeEntityTypeConfiguration
    : IEntityTypeConfiguration<Office>
{
    public void Configure(EntityTypeBuilder<Office> builder)
    {
        builder.HasKey(o => o.Id);

        builder
            .HasMany(o => o.Doctors)
            .WithOne(d => d.Office);

        builder
            .HasMany(o => o.Receptionists)
            .WithOne(r => r.Office);

        builder
            .Property(o => o.City).IsRequired();
        builder
            .Property(o => o.RegistryPhoneNumber).IsRequired();
        builder
            .Property(o => o.Doctors).IsRequired();
        builder
            .Property(o => o.Receptionists).IsRequired();
    }
}
