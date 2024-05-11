using DatumIT_Blog.Application.Interfaces;
using DatumIT_Blog.Infraestructure.Domain.Entities;
using DatumIT_Blog.Infraestructure.Domain.Interfaces;

namespace DatumIT_Blog.Application.Services;

public class ServiceBlog : IServiceBlog
{
    private readonly IRepositoryBase<Blog> _repositoryBase;

    public ServiceBlog(IRepositoryBase<Blog> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task Create(Blog obj)
    {
        try
        {
            _ = _repositoryBase.Create(new()
            {
                Url = obj.Url
            });

            await _repositoryBase.SaveAsync();
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }

    public async Task<IEnumerable<Blog>> Read()
    {
        try
        {
            var result = await _repositoryBase.Read();
            return result.OrderBy(e => e.BlogId);
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }

    public async Task Update(Blog obj)
    {
        try
        {
            var dbObj = await _repositoryBase.GetByIdAsync(e => e.BlogId == obj.BlogId);

            if (dbObj is null) new Exception("Blog not found.");

            _repositoryBase.Update(obj);

            await _repositoryBase.SaveAsync();
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }

    public async Task Delete(int id)
    {
        try
        {
            var dbObj = await _repositoryBase.GetByIdAsync(e => e.BlogId == id);

            if (dbObj is null) new Exception("Blog not found.");

            _repositoryBase.Delete(new()
            {
                BlogId = id
            });

            await _repositoryBase.SaveAsync();
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
}