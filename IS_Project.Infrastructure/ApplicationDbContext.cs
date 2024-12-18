using IS_Project.Application.Common.Data;
using IS_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IS_Project.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
{
    public DbSet<Performer> Performers { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectTask> ProjectTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder optionsBuilder)
    {
        optionsBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
