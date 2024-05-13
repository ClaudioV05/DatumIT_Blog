using DatumIT_Blog.Infraestructure.Data.Context;
using Microsoft.AspNetCore.Identity;

namespace DatumIT_Blog.Presentation.Api.Extensions;

public static class DatabaseDependenciesExtensions
{
    /// <summary>
    /// Configure database dependencies.
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureDatabaseDependencies(this IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>();

        services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;

            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 8;
            options.Password.RequiredUniqueChars = 3;
        }
        ).AddEntityFrameworkStores<DatabaseContext>();
    }
}