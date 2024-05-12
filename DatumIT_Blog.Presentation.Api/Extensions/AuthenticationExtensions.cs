using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DatumIT_Blog.Presentation.Api.Extensions;

public static class AuthenticationExtensions
{
    /// <summary>
    /// Configure authentication.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="builder"></param>
    public static void ConfigureAuthentication(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder?.Configuration["Jwt:Issuer"],
                    ValidAudience = builder?.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder?.Configuration["Jwt:Key"]))
                };
        });
    }
}