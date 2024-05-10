using DatumIT_Blog.Infraestructure.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatumIT_Blog.Infraestructure.Domain.Entities;

/// <summary>
/// Entity Users.
/// </summary>
[ComplexType]
[Table("Users")]
public class Users : IEntity
{
    [Key]
    public long Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
    public string? Name { get; set; }
}