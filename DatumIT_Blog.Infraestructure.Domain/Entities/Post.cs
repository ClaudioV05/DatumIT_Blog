using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DatumIT_Blog.Infraestructure.Domain.Entities;

/// <summary>
/// Entity Post.
/// </summary>
[ComplexType]
public class Post
{
    public int PostId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }

    public int BlogId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Blog Blog { get; set; }
}