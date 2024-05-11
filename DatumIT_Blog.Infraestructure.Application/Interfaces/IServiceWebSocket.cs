﻿namespace DatumIT_Blog.Application.Interfaces;

public interface IServiceWebSocket
{
    /// <summary>
    /// Get message notification create new post.
    /// </summary>
    /// <param name="userName"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The message informative to user.</returns>
    Task SendNotificationPostCreated(string userName);
}