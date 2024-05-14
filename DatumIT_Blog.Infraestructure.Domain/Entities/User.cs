using System.ComponentModel.DataAnnotations.Schema;

namespace DatumIT_Blog.Infraestructure.Domain.Entities;

/// <summary>
/// Entity User.
/// </summary>
[NotMapped]
public class User
{
    public long Id { get; set; }

    public string? UserName { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }
}