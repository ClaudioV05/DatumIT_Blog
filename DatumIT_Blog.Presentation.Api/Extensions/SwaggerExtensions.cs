using Microsoft.OpenApi.Models;

namespace DatumIT_Blog.Presentation.Api.Extensions;

public static class SwaggerExtensions
{
    /// <summary>
    /// Configure swagger.
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new()
            {
                Title = "Datum IT",
                Version = "v1",
                Description = "Simple CRUD"
            });

            c.AddSecurityDefinition("Bearer", new()
            {
                Description = "The authorization header will be automatically generated when you send the request.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });
        });
    }
}