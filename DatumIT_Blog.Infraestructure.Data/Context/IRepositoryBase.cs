using System.Linq.Expressions;

namespace DatumIT_Blog.Infraestructure.Data.Context;

public interface IRepositoryBase<T> where T : class
{
    /// <summary>
    /// Create.
    /// </summary>
    /// <param name="entity"></param>
    Task Create(T entity);

    /// <summary>
    /// Read.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<T>> Read();

    /// <summary>
    /// Get by id async.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Update.
    /// </summary>
    /// <param name="entity"></param>
    void Update(T entity);

    /// <summary>
    /// Delete.
    /// </summary>
    /// <param name="entity"></param>
    void Delete(T entity);

    /// <summary>
    /// SaveAsync.
    /// </summary>
    /// <returns></returns>
    Task SaveAsync();
}