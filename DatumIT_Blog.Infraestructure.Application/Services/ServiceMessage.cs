using DatumIT_Blog.Application.Interfaces;
using System.Text;

namespace DatumIT_Blog.Application.Services;

public class ServiceMessage : IServiceMessage
{
    public ServiceMessage() { }

    public async Task<byte[]> GetMessagePostCreated(string userName)
    {
        try
        {
            return Encoding.ASCII.GetBytes($"User: {userName.ToUpperInvariant()} created the new Post at platform Datum IT Blog. {DateTime.Now}");
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
}