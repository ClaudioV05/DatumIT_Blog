using Microsoft.AspNetCore.Cors.Infrastructure;

namespace DatumIT_Blog.Presentation.Api.Extensions;

public static class CorsExtensions
{
    /// <summary>
    /// Configure Cross-Origin Resource Sharing (CORS).
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureCors(this IServiceCollection services)
    {
        var corsBuilder = new CorsPolicyBuilder();
        corsBuilder.AllowAnyHeader();
        corsBuilder.AllowAnyMethod();
        corsBuilder.AllowAnyOrigin();

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(corsBuilder.Build());
        });
    }
}