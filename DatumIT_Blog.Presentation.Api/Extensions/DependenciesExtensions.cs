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
        services.AddScoped<FilterActionContextController>();
        services.AddScoped<FilterActionContextLog>();
    }
}