using IS_Project.Identity.JWT.Services;
using IS_Project.Identity.PasswordHasher;
using Microsoft.Extensions.DependencyInjection;

namespace IS_Project.Identity;

public static class DependencyInjection
{
    public static void AddAuthServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();

        services.AddScoped<IPasswordHasherService, PasswordHasherService>();
    }
}
