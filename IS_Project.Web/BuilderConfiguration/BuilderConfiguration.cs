using IS_Project.Infrastructure;
using System.Reflection;
using IS_Project.Application;

namespace IS_Project.Web.BuilderConfiguration
{
    public static class BuilderConfiguration
    {
        public static void BuildConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => {
                UriBuilder uri = new UriBuilder(Assembly.GetExecutingAssembly().Location);
                
                string path = Uri.UnescapeDataString(uri.Path);
                
                c.IncludeXmlComments(Path.Combine(Path.GetDirectoryName(path) ?? string.Empty,
                    $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            });

            builder.Services.AddApplication();

            builder.Services.AddInfrastructure(builder.Configuration);
        }
    }
}
