using IS_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IS_Project.Application.Common.Data;

public interface IApplicationDbContext
{
    DbSet<Performer> Performers { get; }
    DbSet<Project> Projects { get; }
    DbSet<ProjectTask> ProjectTasks { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
