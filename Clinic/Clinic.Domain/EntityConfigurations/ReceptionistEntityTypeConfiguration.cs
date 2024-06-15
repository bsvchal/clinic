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
    }
}
