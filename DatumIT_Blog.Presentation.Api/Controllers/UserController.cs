using DatumIT_Blog.Presentation.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DatumIT_Blog.Presentation.Api.Controllers;

[ApiController]
[Route("[controller]")]
/*[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]*/
public class UserController : ControllerBase
{
    /// <summary>
    /// User Login.
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    [HttpGet]
    [Route("/Admins")]
    [Authorize(Roles = "Admin")]
    /*[Produces(MediaTypeNames.Application.Json)]
    [ApiExplorerSettings(IgnoreApi = false)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]*/
    public IActionResult Admins()
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
}