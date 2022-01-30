namespace TestMVCServer.Server

{
    using System.Net;
    using System.Text;
    using System.Net.Sockets;
    using TestMVCServer.Server.Routing;
    using TestMVCServer.Server.Http;

    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener listener;

        private readonly RoutingTable routingTable;

        public HttpServer(string ipAddress, int port, Action<IRoutingTable> routingTableConfiguration)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;

            this.listener = new TcpListener(this.ipAddress, port);

            this.routingTable = new RoutingTable();
            routingTableConfiguration(this.routingTable);
        }

        public HttpServer(int port, Action<IRoutingTable> routingTable)
         : this("127.0.0.1", port, routingTable)
        { }

        public HttpServer(Action<IRoutingTable> routingTable)
            : this(9090, routingTable)
        { }

        public async Task Start()
        {

            this.listener.Start();

            Console.WriteLine("Connection established...");
            Console.WriteLine($"HTTP Server listening on port {port} ...");

            while (true)
            {
                var connection = await listener.AcceptTcpClientAsync();

                var networkStream = connection.GetStream();

                var requestText = await ReadRequest(networkStream, connection);
                try
                {
                    var request = HttpRequest.Parse(requestText);

                    var response = this.routingTable.ExecuteRequest(request);

                    this.PrepareSession(request, response);

                    this.LogPipeLine(request, response);

                    await WriteResponse(networkStream, response);
                }
                catch (Exception exeption)
                {
                    await HandleError(networkStream, exeption);
                }

                connection.Close();
            }
        }


        private async Task WriteResponse(
            NetworkStream networkStream, HttpResponse response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());
            await networkStream.WriteAsync(responseBytes);
        }

        private async Task HandleError(NetworkStream networkStream, Exception exeption)
        {
            var errorMesage = $"{exeption.Message}{Environment.NewLine}{exeption.StackTrace}";

            var errorResponse = HttpResponse.ForError(errorMesage);

            await WriteResponse(networkStream, errorResponse);
        }

        private async Task<string> ReadRequest(NetworkStream networkStream, TcpClient connection)
        {

            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var totalBytes = 0;

            StringBuilder requestBuilder = new StringBuilder();

            do
            {
                var byteRead = await networkStream.ReadAsync(buffer, 0, bufferLength);

                totalBytes += byteRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is to large.");
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, byteRead));
            }
            while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }

        private void PrepareSession(HttpRequest request, HttpResponse response)
            => response.AddCookie(HttpSession.SessionCookieName, request.Session.Id);

        private void LogPipeLine(HttpRequest request, HttpResponse response)
        {
            var sb = new StringBuilder();

            var separator = new string('-', 50);

            sb.AppendLine();
            sb.AppendLine(separator);

            sb.AppendLine("REQUEST");
            sb.AppendLine(request.ToString());

            sb.AppendLine();

            sb.AppendLine("RESPONSE");
            sb.AppendLine(response.ToString());

            sb.AppendLine();

            Console.WriteLine(sb.ToString());

        }
    }
}