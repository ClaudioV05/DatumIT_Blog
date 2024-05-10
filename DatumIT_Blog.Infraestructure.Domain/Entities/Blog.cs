using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DatumIT_Blog.Infraestructure.Domain.Entities;

/// <summary>
/// Entity Blog.
/// </summary>
[ComplexType]
public class Blog
{
    public int BlogId { get; set; }

    public string Url { get; set; } = string.Empty;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Post> Posts { get; set; } = new();
}