using DatumIT_Blog.Application.Interfaces;
using DatumIT_Blog.Infraestructure.Domain.Entities;
using DatumIT_Blog.Presentation.Api.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net.Mime;

namespace DatumIT_Blog.Presentation.Api.Controllers;

[ApiController]
[Route("[Controller]")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[ServiceFilter(typeof(FilterActionContextController), Order = 1)]
public class DatumIT_BlogController : ControllerBase
{
    private readonly IServiceUsers _serviceUsers;

    public DatumIT_BlogController(IServiceUsers serviceUsers)
    {
        _serviceUsers = serviceUsers;
    }

    /// <summary>
    /// Create new Users.
    /// </summary>
    /// <param name="users"></param>
    /// <returns></returns>
    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/Create")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [ServiceFilter(typeof(FilterActionContextLog), Order = 2)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([BindRequired] Users users)
    {
        try
        {
            await _serviceUsers.Create(users);
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
    /// Get Users.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/Read")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [ServiceFilter(typeof(FilterActionContextLog), Order = 2)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Read()
    {
        try
        {
            var result = await _serviceUsers.Read();
            return Ok(result);
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
    /// Update new Users.
    /// </summary>
    /// <param name="users"></param>
    /// <returns></returns>
    [HttpPut]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/Update")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [ServiceFilter(typeof(FilterActionContextLog), Order = 2)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([BindRequired] Users users)
    {
        try
        {
            await _serviceUsers.Update(users);
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
    /// Delete new Users.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/Delete")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [ServiceFilter(typeof(FilterActionContextLog), Order = 2)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete([BindRequired] int id)
    {
        try
        {
            await _serviceUsers.Delete(id);
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
}