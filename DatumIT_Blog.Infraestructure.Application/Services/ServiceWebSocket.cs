using DatumIT_Blog.Application.Interfaces;
using System.Net.WebSockets;

namespace DatumIT_Blog.Application.Services;

public class ServiceWebSocket : IServiceWebSocket
{
    private readonly IServiceMessage _serviceMessage;

    public ServiceWebSocket(IServiceMessage serviceMessage)
    {
        _serviceMessage = serviceMessage;
    }

    public async Task SendNotificationPostCreated(string userName)
    {
        WebSocketContext? webSocketContext = null;

        try
        {
            WebSocket? webSocket = webSocketContext?.WebSocket;

            if (webSocket?.State is WebSocketState.Open)
            {
                await webSocket.SendAsync(await _serviceMessage.GetMessagePostCreated(userName), WebSocketMessageType.Binary, false, CancellationToken.None);
            }
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
}