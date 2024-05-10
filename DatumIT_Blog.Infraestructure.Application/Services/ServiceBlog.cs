using DatumIT_Blog.Application.Interfaces;
using DatumIT_Blog.Infraestructure.Data.Context;
using DatumIT_Blog.Infraestructure.Domain.Entities;

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
            _repositoryBase.Create(new()
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
            return result.OrderBy(x => x.BlogId);
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
            _repositoryBase.Update(new()
            {
                BlogId = obj.BlogId,
                Url = obj.Url
            });

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