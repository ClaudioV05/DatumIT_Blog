using DatumIT_Blog.Infraestructure.Domain.Entities;

namespace DatumIT_Blog.Application.Interfaces;

public interface IServicePost
{
    /// <summary>
    /// Create.
    /// </summary>
    /// <param name="obj"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    Task Create(Post obj);

    /// <summary>
    /// Read.
    /// </summary>
    /// <param name=""></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    Task<IEnumerable<Post>> Read();

    /// <summary>
    /// Update.
    /// </summary>
    /// <param name="obj"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    Task Update(Post obj);

    /// <summary>
    /// Delete.
    /// </summary>
    /// <param name="id"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    Task Delete(int id);
}