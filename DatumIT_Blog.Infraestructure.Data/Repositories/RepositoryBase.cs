using DatumIT_Blog.Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DatumIT_Blog.Infraestructure.Data.Repositories;

/// <summary>
/// RepositoryBase.
/// </summary>
/// <typeparam name="T"></typeparam>
public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected DatabaseContext _context;

    /// <summary>
    /// RepositoryBase.
    /// </summary>
    /// <param name="context"></param>
    public RepositoryBase(DatabaseContext context)
    {
        _context = context;
    }

    public async Task Create(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task<IEnumerable<T>> Read()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(predicate);
    }

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}