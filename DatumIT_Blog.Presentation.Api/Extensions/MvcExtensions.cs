using Microsoft.AspNetCore.Mvc.Formatters;

namespace DatumIT_Blog.Presentation.Api.Extensions;

public static class MvcExtensions
{
    /// <summary>
    /// Configure mvc.
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureMvc(this IServiceCollection services)
    {
        services.AddMvc()
                .AddMvcOptions(options => options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));
    }
}