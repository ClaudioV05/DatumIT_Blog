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
    private readonly IServiceBlog _serviceBlog;

    public DatumIT_BlogController(IServiceBlog serviceBlog)
    {
        _serviceBlog = serviceBlog;
    }

    /// <summary>
    /// Create new Blog.
    /// </summary>
    /// <param name="blog"></param>
    /// <returns></returns>
    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/Create")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [ServiceFilter(typeof(FilterActionContextLog), Order = 2)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([BindRequired] Blog blog)
    {
        try
        {
            await _serviceBlog.Create(blog);
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
    /// Get Blog.
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
            var result = await _serviceBlog.Read();
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
    /// Update new Blog.
    /// </summary>
    /// <param name="blog"></param>
    /// <returns></returns>
    [HttpPut]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/Update")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [ServiceFilter(typeof(FilterActionContextLog), Order = 2)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([BindRequired] Blog blog)
    {
        try
        {
            await _serviceBlog.Update(blog);
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
    /// Delete new Blog.
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
            await _serviceBlog.Delete(id);
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