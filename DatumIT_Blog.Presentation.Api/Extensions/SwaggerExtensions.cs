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
        services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo
        { 
            Title = "Datum IT", 
            Version = "v1",
            Description = "Simple CRUD"
        }));
    }
}