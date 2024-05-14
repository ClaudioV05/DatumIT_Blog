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
        services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new()
            {
                Version = "v1",
                Title = "Datum IT",
                Description = "Action of CRUD test to Datum IT"
            });

            config.AddSecurityDefinition("Bearer", new()
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Description = "The authorization header will be automatically generated when you send the request."
            });
        });
    }
}