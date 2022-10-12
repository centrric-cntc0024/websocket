using Serilog;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Reflection.PortableExecutable;
using System.Text;


namespace sockettestlast.Service
{
    public class WebsocketService 
        
    {
        private readonly string Connection = "wss://api.parkassist.com/example-site/websocket/notifications?type=entry,exit,plate_found,plate_missing,plate_failed?id>3318084200";

        public async Task StartAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
                using (var socket = new ClientWebSocket())
                    try
                    {
                        await socket.ConnectAsync(new Uri(Connection), stoppingToken);
                        await Receivedata(socket,stoppingToken);
                        await Send(socket, "Basic dGVzdC1nb29nZXJpdDpBVkE3U0hxOHh1TVpYS0JB", stoppingToken);
                        await Receive(socket, stoppingToken);

                    }
                    catch (Exception ex)
                    {
                       Log.Information($"ERROR - {ex.Message}");
                    }
        }

        private async Task Send(ClientWebSocket socket, string data, CancellationToken stoppingToken) =>


            await socket.SendAsync(Encoding.UTF8.GetBytes(data), WebSocketMessageType.Text, true, stoppingToken);


        private async Task Receivedata(ClientWebSocket socket, CancellationToken stoppingToken)
        {
            try
            {
                byte[] incomingData = new byte[1024];
                await socket.ReceiveAsync(new ArraySegment<byte>(incomingData), CancellationToken.None);
            }
            catch (Exception ex)
            {
                Log.Information($"ERROR - {ex.Message}");
            }
        }


        private async Task Receive(ClientWebSocket socket, CancellationToken stoppingToken)
        {
            try
            {
                var buffer = new ArraySegment<byte>(new byte[2048]);
                while (!stoppingToken.IsCancellationRequested)
                {
                    WebSocketReceiveResult result;
                    using (var ms = new MemoryStream())
                    {
                        do
                        {
                            result = await socket.ReceiveAsync(buffer, stoppingToken);
                            ms.Write(buffer.Array!, buffer.Offset, result.Count);
                        } while (!result.EndOfMessage);

                        if (result.MessageType == WebSocketMessageType.Close)
                            break;

                        ms.Seek(0, SeekOrigin.Begin);
                        using (var reader = new StreamReader(ms, Encoding.UTF8))
                         
                        Log.Information(await reader.ReadToEndAsync());
                    }
                };
            }

            catch (Exception ex)
            {
                Log.Information($"ERROR - {ex.Message}");
            }

        }
  
    }
}
