using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DatumIT_Blog.Presentation.Api.Swagger;

public class DocumentationHeaderAttribute : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters is null)
        {
            operation.Parameters = new List<OpenApiParameter>();
        }

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = string.Empty,
            In = ParameterLocation.Header,
            Required = false,
            Schema = new OpenApiSchema
            {
                Type = "String"
            }
        });

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = string.Empty,
            In = ParameterLocation.Header,
            Required = false,
            Schema = new OpenApiSchema
            {
                Type = "int"
            }
        });
    }
}