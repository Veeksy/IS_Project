using IS_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS_Project.Infrastructure.Data.Configuration;

public class PerformersConfiguration : IEntityTypeConfiguration<Performer>
{
    public void Configure(EntityTypeBuilder<Performer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .HasMaxLength(150)
            .IsRequired();
            
        builder.Property(x => x.LastName)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.PhoneNumber);

        builder.Property(x => x.AboutMe).HasMaxLength(1500);
    }
}
