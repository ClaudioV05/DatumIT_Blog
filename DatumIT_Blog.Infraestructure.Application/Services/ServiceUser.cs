using DatumIT_Blog.Application.Interfaces;
using DatumIT_Blog.Infraestructure.Domain.Entities;
using DatumIT_Blog.Infraestructure.Domain.Interfaces;

namespace DatumIT_Post.Application.Services;

public class ServiceUser : IServiceUser
{
    private readonly IRepositoryUser _repositoryUsers;

    public ServiceUser(IRepositoryUser repositoryUsers)
    {
        _repositoryUsers = repositoryUsers;
    }

    public async Task<bool> RegisterUser(User user)
    {
        try
        {
           return await _repositoryUsers.RegisterUser(user);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> LoginUser(User user)
    {
        try
        {
            return await _repositoryUsers.LoginUser(user);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}