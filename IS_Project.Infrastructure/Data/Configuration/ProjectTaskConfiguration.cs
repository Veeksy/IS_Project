using IS_Project.Domain.Entities;
using IS_Project.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS_Project.Infrastructure.Data.Configuration;

public class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
{
    public void Configure(EntityTypeBuilder<ProjectTask> builder)
    {
        builder.HasKey(x=> x.Id);

        builder.Property(x=>x.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(1500);

        builder.Property(x => x.ProjectId)
            .IsRequired();

        builder.Property(x => x.TaskStatus)
            .HasDefaultValue(StatusEnum.InWork);

        builder.Property(x => x.Priority)
            .HasDefaultValue(PriorityEnum.Medium);
    }
}
