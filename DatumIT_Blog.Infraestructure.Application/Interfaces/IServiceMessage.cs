namespace DatumIT_Blog.Application.Interfaces;

public interface IServiceMessage
{
    /// <summary>
    /// Get message to new post created.
    /// </summary>
    /// <param name="userName"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The message informative to user.</returns>
    Task<byte[]> GetMessagePostCreated(string userName);
}