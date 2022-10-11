using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
//using WebSocketSharp;
namespace sockettestlast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class websocketController : ControllerBase
    {

        
       
        //public  async Task RunWebSocketClient()
        //{
        //    using (ClientWebSocket websocket = new ClientWebSocket())
        //    {
        //        string url = "wss://api.parkassist.com/example-site/websocket/notifications?type=entry,exit,plate_found,plate_missing,plate_failed?id>3318084200";
        //        Console.WriteLine("Connecting to: " + url);

        //        await websocket.ConnectAsync(new Uri(url), CancellationToken.None);
        //        string message = "Basic dGVzdC1nb29nZXJpdDpBVkE3U0hxOHh1TVpYS0JB";

        //        Debug.WriteLine("Sending message: " + message);
        //        byte[] messageBytes = Encoding.UTF8.GetBytes(message);
        //        // await websocket.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true, CancellationToken.None);
        //        byte[] incomingData = new byte[1024];

        //        WebSocketReceiveResult result = await websocket.ReceiveAsync(new ArraySegment<byte>(incomingData), CancellationToken.None);

        //        await websocket.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true, CancellationToken.None);

        //        WebSocketReceiveResult newresult = await websocket.ReceiveAsync(new ArraySegment<byte>(incomingData), CancellationToken.None);
        //        Debug.WriteLine("Received message: " + Encoding.UTF8.GetString(incomingData, 0, newresult.Count));
        //    }
            //if (newresult.CloseStatus.HasValue)
            //{
            //    Console.WriteLine("Closed; Status: " + newresult.CloseStatus + ", " + newresult.CloseStatusDescription);
            //}
            //else
            //{
            //    var dataa = incomingData;
            //    Debug.WriteLine("Received message: " + Encoding.UTF8.GetString(incomingData, 0, newresult.Count));
            //    Debug.WriteLine("result",newresult);
            //}
       // }
        //using (var ws = new ClientWebSocket())
        //{
        //    await ws.ConnectAsync(new Uri("wss://api.parkassist.com/example-site/websocket/notifications?type=entry,exit,plate_found,plate_missing,plate_failed?id>3318084338"), CancellationToken.None);
        //    var buffer = new byte[256];

        //    while (ws.State == WebSocketState.Open)
        //    {
        //        ws.Send( "Basic dGVzdC1nb29nZXJpdDpBVkE3U0hxOHh1TVpYS0JB");
        //        var result = await ws.ReceiveAsync(buffer, CancellationToken.None);
        //        if (result.MessageType == WebSocketMessageType.Close)
        //        {
        //            await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
        //        }
        //        else
        //        {
        //            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, result.Count));
        //        }
        //    }
        //}

        //WebSocket ws = new WebSocket("wss://api.parkassist.com/example-site/websocket/notifications?type=entry,exit,plate_found,plate_missing,plate_failed?id>3318084338");
        //ws.ConnectAsync();
        //ws.Send("Basic dGVzdC1nb29nZXJpdDpBVkE3U0hxOHh1TVpYS0JB");
    
    }
}
