using DatumIT_Blog.Application.Interfaces;
using DatumIT_Blog.Infraestructure.Domain.Entities;
using DatumIT_Blog.Presentation.Api.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net.Mime;
using System.Net.WebSockets;

namespace DatumIT_Post.Presentation.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[ServiceFilter(typeof(FilterActionContextController), Order = 1)]
public class PostsController : ControllerBase
{
    private readonly IServicePost _servicePost;
    private readonly IServiceWebSocket _serviceWebSocket;

    public PostsController(IServicePost servicePost, IServiceWebSocket serviceWebSocket)
    {
        _servicePost = servicePost;
        _serviceWebSocket = serviceWebSocket;
    }

    /// <summary>
    /// Create new Post.
    /// </summary>
    /// <param name="Post"></param>
    /// <returns></returns>
    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/CreatePosts")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [ServiceFilter(typeof(FilterActionContextLog), Order = 2)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([BindRequired] Post Post)
    {
        try
        {
            await _servicePost.Create(Post);
            await this.SendNotitifcation();
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
    /// Get Post.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/ReadPosts")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [ServiceFilter(typeof(FilterActionContextLog), Order = 2)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Read()
    {
        try
        {
            var result = await _servicePost.Read();
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
    /// Update new Post.
    /// </summary>
    /// <param name="Post"></param>
    /// <returns></returns>
    [HttpPut]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/UpdatePosts")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [ServiceFilter(typeof(FilterActionContextLog), Order = 2)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([BindRequired] Post Post)
    {
        try
        {
            await _servicePost.Update(Post);
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
    /// Delete new Post.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/DeletePosts")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [ServiceFilter(typeof(FilterActionContextLog), Order = 2)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete([BindRequired] int id)
    {
        try
        {
            await _servicePost.Delete(id);
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


    #region Config methods.

    private async Task SendNotitifcation()
    {
        try
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await webSocket.SendAsync(await _serviceWebSocket.GetMessageNotificationCreatePost("Claudio"), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
        catch (Exception)
        {
            throw new Exception();
        }

        #endregion Config methods.
    }
}