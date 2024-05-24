namespace DatumIT_Blog.Application.Interfaces;

/// <summary>
/// IServiceJsonWebToken
/// </summary>
/// <remarks>This class cannot be inherited.</remarks>
public interface IServiceJsonWebToken
{
    /// <summary>
    /// Generate the json web token.
    /// </summary>
    /// <param name="userName"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The json web token.</returns>
    string GenerateTheJsonWebToken(string userName);
}