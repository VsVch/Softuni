using SUWebServer.Srever.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SUWebServer.Srever
{
    public class HttpServer
    {
        private readonly IPAddress ipAddres;
        private readonly int port;
        private readonly TcpListener serverListener;

        private readonly RoutingTable routingTable;

        public HttpServer(
            int port,
            Action<IRoutingTable> routingTable)
            : this("127.0.0.1", port, routingTable)
        {
        }

        public HttpServer(Action<IRoutingTable> routingTable)
            : this(8080, routingTable)
        {
        }

        public HttpServer(
            string ipAddres,
            int port,
            Action <IRoutingTable> routingTableConfiguration)
        {
            this.ipAddres = IPAddress.Parse(ipAddres);
            this.port = port;

            this.serverListener = new TcpListener(this.ipAddres, port);

            routingTableConfiguration(this.routingTable = new RoutingTable());
        }

        public async Task Start()
        {
            this.serverListener.Start();

            Console.WriteLine($"Server started on potr {this.port}...!");
            Console.WriteLine($"Listening for request...");

            while (true)
            {
                var connection = await serverListener.AcceptTcpClientAsync();

                _ = Task.Run(async () =>
                {
                    var networkStreem = connection.GetStream();                   

                    var requestText = await ReadRequest(networkStreem);

                    Console.WriteLine(requestText);

                    var request = Request.Parse(requestText);

                    var response = this.routingTable.MatchRequest(request);
                    
                    if (response.PreRenderAction != null)
                    {
                        response.PreRenderAction(request, response);
                    }

                   await WriteResponse(networkStreem, response);

                    connection.Close();
                });
            }
        }

        private async Task WriteResponse(NetworkStream networkStreem, Response response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());  
            
            await networkStreem.WriteAsync(responseBytes);
        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var bufferLenght = 1024;
            var buffer = new byte[bufferLenght];

            var requestBuilder = new StringBuilder();
            var totalbytes = 0;
            do
            {
                var bytesRead = await networkStream.ReadAsync(
                    buffer, 0, bufferLenght);

                totalbytes += bytesRead;

                if (totalbytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is ti large.");
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bufferLenght));

            } while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }
    }
}
