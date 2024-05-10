using DatumIT_Blog.Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DatumIT_Blog.Infraestructure.Data.Repositories;

/// <summary>
/// RepositoryBase.
/// </summary>
/// <typeparam name="T"></typeparam>
public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected DatabaseContext _dbContext;

    /// <summary>
    /// RepositoryBase.
    /// </summary>
    /// <param name="dbContext"></param>
    public RepositoryBase(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(T entity) => _dbContext.Set<T>().Add(entity);
    
    public Task<List<T>> Read() => _dbContext.Set<T>().AsNoTracking().ToListAsync();

    public void Update(T entity) => _dbContext.Set<T>().Update(entity);

    public void Delete(T entity) => _dbContext.Set<T>().Remove(entity);

    public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
}