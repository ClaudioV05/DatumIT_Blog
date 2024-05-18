using DatumIT_Blog.Infraestructure.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DatumIT_Blog.Presentation.Api.Extensions;

public static class DatabaseProviderExtensions
{
    /// <summary>
    /// Configure database dependencies.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void ConfigureDatabaseDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration["ConnectionStrings:DatabaseConnection"]?.ToString();

        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(connection, configure =>
            {
                configure.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                configure.MigrationsAssembly(configuration["PresentationProjectName"]);
            });
        });


        services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 8;
            options.Password.RequiredUniqueChars = 3;
        }).AddEntityFrameworkStores<DatabaseContext>();
    }
}