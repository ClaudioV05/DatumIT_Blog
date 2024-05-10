using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DatumIT_Blog.Presentation.Api.Swagger;

public class DocumentationAttribute : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        swaggerDoc.Info = new OpenApiInfo
        {
            Version = "v1",
            Title = "DatumIT_Blog",
            Description = "DatumIT_Blog with EF using SQLServer",
            TermsOfService = new Uri("https://claudiomildo.net/terms"),
            Contact = new OpenApiContact
            {
                Name = "Claudio Ventura",
                Email = "claudiomildo@hotmail.com",
                Url = new Uri("https://www.claudiomildo.net"),
            },
            License = new OpenApiLicense
            {
                Name = "Information about the license.",
                Url = new Uri("https://claudiomildo.net/license"),
            }
        };
    }
}