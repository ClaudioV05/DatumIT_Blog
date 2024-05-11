using DatumIT_Blog.Application.Interfaces;
using System.Text;

namespace DatumIT_Blog.Application.Services;

public class ServiceWebSocket : IServiceWebSocket
{
    public ServiceWebSocket()
    {

    }

    public async Task<byte[]> GetMessageNotificationCreatePost(string user)
    {
        try
        {
            return Encoding.ASCII.GetBytes($"User: {user.ToUpperInvariant()} created the new Post at platform Datum IT Blog. {DateTime.Now}");
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
}