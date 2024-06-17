using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Domain.EntityConfigurations;

public class ReceptionistEntityTypeConfiguration
    : IEntityTypeConfiguration<Receptionist>
{
    public void Configure(EntityTypeBuilder<Receptionist> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasOne(r => r.Account);

        builder
            .HasOne(r => r.Office)
            .WithMany(o => o.Receptionists)
            .HasForeignKey(r => r.OfficeId);

        builder
            .Property(r => r.FirstName).IsRequired();
        builder
            .Property(r => r.LastName).IsRequired();
        builder
            .Property(r => r.MiddleName).IsRequired();
        builder
            .Property(r => r.Account).IsRequired();
        builder
            .Property(r => r.Office).IsRequired();
    }
}
