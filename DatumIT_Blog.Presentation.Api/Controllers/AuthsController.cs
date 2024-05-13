using DatumIT_Blog.Application.Interfaces;
using DatumIT_Blog.Presentation.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;

namespace DatumIT_Blog.Presentation.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
public class AuthsController : ControllerBase
{
    private readonly IServiceUser _serviceUser;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// AuthsController.
    /// </summary>
    /// <param name="serviceUser"></param>
    /// <param name="configuration"></param>
    public AuthsController(IServiceUser serviceUser, IConfiguration configuration)
    {
        _serviceUser = serviceUser;
        _configuration = configuration;
    }

    /// <summary>
    /// Register user.
    /// </summary>
    /// <param name="userLogin"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    [Route("/RegisterUser")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegisterUser([BindRequired] UserLogin userLogin)
    {
        try
        {
            bool result = await _serviceUser.RegisterUser(new()
            {
                Email = userLogin.Email,
                UserName = userLogin.Username,
                Password = userLogin.Password
            });

            if (result)
            {
                //var token = GenerateJSONWebToken(new() { Username = "naeem", Password = "naeem_admin", Role = "Admin" });
                var token = GenerateJSONWebToken(new()
                {
                    Username = userLogin.Username,
                    Password = userLogin.Password,
                    Role = "Admin"
                });

                return Ok(token);
            }

            return NotFound("user not found");
        }
        catch (HttpRequestException ex) when (ex.StatusCode.Equals(System.Net.HttpStatusCode.BadRequest))
        {
            return this.StatusCode(StatusCodes.Status400BadRequest);
        }
        catch (HttpRequestException ex) when (ex.StatusCode.Equals(System.Net.HttpStatusCode.InternalServerError))
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Login user.
    /// </summary>
    /// <param name="userLogin"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    [Route("/LoginUser")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> LoginUser([BindRequired] UserLogin userLogin)
    {
        try
        {
            await _serviceUser.LoginUser(new()
            {
                Email = userLogin.Email,
                UserName = userLogin.Username,
                Password = userLogin.Password
            });

            return Ok();
        }
        catch (HttpRequestException ex) when (ex.StatusCode.Equals(System.Net.HttpStatusCode.BadRequest))
        {
            return this.StatusCode(StatusCodes.Status400BadRequest);
        }
        catch (HttpRequestException ex) when (ex.StatusCode.Equals(System.Net.HttpStatusCode.InternalServerError))
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Validate User.
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    [HttpGet]
    [Route("/ValidateUser")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult ValidateUser()
    {
        try
        {
            var currentUser = GetCurrentUser();

            return Ok($"Hi you are an {currentUser.Role}");
        }
        catch (HttpRequestException ex) when (ex.StatusCode.Equals(System.Net.HttpStatusCode.BadRequest))
        {
            return this.StatusCode(StatusCodes.Status400BadRequest);
        }
        catch (HttpRequestException ex) when (ex.StatusCode.Equals(System.Net.HttpStatusCode.InternalServerError))
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    private UserModel GetCurrentUser()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;

        if (identity is not null)
        {
            var userClaims = identity.Claims;

            return new UserModel
            {
                Username = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
            };
        }

        return null;
    }

    private string GenerateJSONWebToken(UserModel user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
                new Claim(ClaimTypes.NameIdentifier,user.Username),
                new Claim(ClaimTypes.Role,user.Role)
        };

        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(15), signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}