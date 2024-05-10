using DatumIT_Blog.Application.Interfaces;
using DatumIT_Blog.Infraestructure.Data.Context;
using DatumIT_Blog.Infraestructure.Domain.Entities;

namespace DatumIT_Blog.Application.Services;

public class ServiceUsers : IServiceUsers
{
    private readonly IRepositoryBase<Users> _repositoryBase;

    public ServiceUsers(IRepositoryBase<Users> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task Create(Users obj)
    {
        try
        {
            _repositoryBase.Create(new()
            {
                Name = obj.Name
            });

            await _repositoryBase.SaveAsync();
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }

    public async Task<IEnumerable<Users>> Read()
    {
        try
        {
            var result = await _repositoryBase.Read();
            return result.OrderBy(x => x.Id);
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }

    public async Task Update(Users obj)
    {
        try
        {
            _repositoryBase.Update(new()
            {
                Id = obj.Id,
                Name = obj.Name
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
                Id = id
            });

            await _repositoryBase.SaveAsync();
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
}