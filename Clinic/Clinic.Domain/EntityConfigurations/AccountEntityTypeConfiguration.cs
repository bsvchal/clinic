using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Domain.EntityConfigurations;

public class AccountEntityTypeConfiguration
    : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Photo);

        builder.Property(a => a.Email).IsRequired();
        builder.Property(a => a.Password).IsRequired();
        builder.Property(a => a.PhoneNumber).IsRequired();
    }
}
