using System.Text.Json;

namespace DatumIT_Blog.Presentation.Api.Models;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public string? StackTrace { get; set; }
    public string? Source { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}