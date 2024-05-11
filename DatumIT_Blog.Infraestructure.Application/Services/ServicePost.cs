using DatumIT_Blog.Application.Interfaces;
using DatumIT_Blog.Infraestructure.Domain.Entities;
using DatumIT_Blog.Infraestructure.Domain.Interfaces;

namespace DatumIT_Post.Application.Services;

public class ServicePost : IServicePost
{
    private readonly IRepositoryBase<Post> _repositoryBase;

    public ServicePost(IRepositoryBase<Post> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task Create(Post obj)
    {
        try
        {
            _ = _repositoryBase.Create(new()
            {
                BlogId = obj.BlogId,
                Title = obj.Title,
                Content = obj.Content,
                CreatedDate = DateTime.Now,
            });

            await _repositoryBase.SaveAsync();
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }

    public async Task<IEnumerable<Post>> Read()
    {
        try
        {
            var result = await _repositoryBase.Read();
            return result.OrderBy(e => e.PostId);
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }

    public async Task Update(Post obj)
    {
        try
        {
            var dbObj = await _repositoryBase.GetByIdAsync(e => e.PostId == obj.PostId);

            if (dbObj is null) new Exception("Post not found.");

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
            var dbObj = await _repositoryBase.GetByIdAsync(e => e.PostId == id);

            if (dbObj is null) new Exception("Post not found.");

            _repositoryBase.Delete(new()
            {
                PostId = id
            });

            await _repositoryBase.SaveAsync();
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
}