using DatumIT_Blog.Application.Interfaces;
using DatumIT_Blog.Presentation.Api.Models;
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
    private readonly IServiceJsonWebToken _serviceJsonWebToken;

    /// <summary>
    /// AuthsController.
    /// </summary>
    /// <param name="serviceUser"></param>
    /// <param name="serviceJsonWebToken"></param>
    public AuthsController(IServiceUser serviceUser, IServiceJsonWebToken serviceJsonWebToken)
    {
        _serviceUser = serviceUser;
        _serviceJsonWebToken = serviceJsonWebToken;
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
            await _serviceUser.RegisterUser(new()
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
            bool result = await _serviceUser.LoginUser(new()
            {
                Email = userLogin.Email,
                UserName = userLogin.Username,
                Password = userLogin.Password
            });

            if (result)
            {
                return Ok(_serviceJsonWebToken.GenerateTheJsonWebToken(userLogin.Username, "Admin"));
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
}