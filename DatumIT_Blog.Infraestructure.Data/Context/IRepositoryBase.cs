namespace DatumIT_Blog.Infraestructure.Data.Context;

public interface IRepositoryBase<T> where T : class
{
    /// <summary>
    /// Create.
    /// </summary>
    /// <param name="entity"></param>
    void Create(T entity);

    /// <summary>
    /// Read.
    /// </summary>
    /// <returns></returns>
    Task<List<T>> Read();

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