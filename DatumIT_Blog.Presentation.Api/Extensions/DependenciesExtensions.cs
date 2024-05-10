using DatumIT_Blog.Infraestructure.Data.Context;
using DatumIT_Blog.Presentation.Api.Filters;

namespace DatumIT_Blog.Presentation.Api.Extensions;

public static class DependenciesExtensions
{
    /// <summary>
    /// Configure dependencies.
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureDependencies(this IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>();

        services.AddScoped<FilterActionContextController>();
        services.AddScoped<FilterActionContextLog>();
    }
}