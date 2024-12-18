using IS_Project.Application.Common.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IS_Project.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var dataBase = configuration.GetSection(nameof(DatabaseConnections)).Get<DatabaseConnections>();

        services.AddDbContextPool<IApplicationDbContext, ApplicationDbContext>(opt =>
             opt.UseNpgsql(dataBase?.IS_DbConnection));

        return services;
    }

    public record DatabaseConnections(
        string IS_DbConnection
        );
}
