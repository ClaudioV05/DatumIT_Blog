using DatumIT_Blog.Infraestructure.Domain.Entities;
using DatumIT_Blog.Infraestructure.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DatumIT_Blog.Infraestructure.Data.Repositories;

/// <summary>
/// RepositoryUser.
/// </summary>
public class RepositoryUser : IRepositoryUser
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public RepositoryUser(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> RegisterUser(User user)
    {
        try
        {
            var newUser = new IdentityUser()
            {
                Email = user.Email,
                UserName = user.UserName
            };

            var result = await _userManager.CreateAsync(newUser, user.Password);

            if (result is not null)
            {
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(newUser, isPersistent: false);
                }
                else if (result.Errors.Any())
                {
                    throw new Exception(result.Errors?.FirstOrDefault()?.Description);
                }
            }

            return true;
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
            var identityUser = await _userManager.FindByEmailAsync(user?.Email);
            var result = await _signInManager.PasswordSignInAsync(identityUser?.UserName, user.Password, false, false);

            return result.Succeeded;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}