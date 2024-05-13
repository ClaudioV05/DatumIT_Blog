using DatumIT_Blog.Infraestructure.Domain.Entities;

namespace DatumIT_Blog.Application.Interfaces;

public interface IServiceUser
{
    /// <summary>
    /// Register User.
    /// </summary>
    /// <param name="user"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    Task<bool> RegisterUser(User user);

    /// <summary>
    /// Login User.
    /// </summary>
    /// <param name="obj"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    Task<bool> LoginUser(User user);
}