using Microsoft.Extensions.DependencyModel;
using Scrutor;
using System.Reflection;

namespace DatumIT_Blog.Presentation.Api.Extensions;

public static class ScrutorExtensions
{
    /// <summary>
    /// Configure dependencies.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="namespace"></param>
    public static void ConfigureDependencies(this IServiceCollection services, string @namespace)
    {
        var assemblies = DependencyContext.Default?
                                          .GetDefaultAssemblyNames()
                                          .Where(assembly => assembly.FullName.StartsWith(@namespace))
                                          .Select(Assembly.Load);

        services.Scan(scan => scan.FromAssemblies(assemblies)
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .WithScopedLifetime());
    }
}