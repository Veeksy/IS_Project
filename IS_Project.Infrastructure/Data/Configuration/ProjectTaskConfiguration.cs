using IS_Project.Domain.Entities;
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

        builder.Property(x => x.ProjectId)
            .IsRequired();

        builder.Property(x => x.TaskStatus)
            .HasDefaultValue(TaskStatus.Created);
    }
}
