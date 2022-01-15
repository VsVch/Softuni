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

        public HttpServer(string ipAddres, int port)
        {
            this.ipAddres = IPAddress.Parse(ipAddres);
            this.port = port;

            this.serverListener = new TcpListener(this.ipAddres, port);
        }

        public void Start() 
        {
            this.serverListener.Start();

            Console.WriteLine($"Server started on potr {this.port}...!");
            Console.WriteLine($"Listening for request...");
            while (true)
            {
                var connection = serverListener.AcceptTcpClient();

                var networkStreem = connection.GetStream();

                WriteResponse(networkStreem, "Hello from the server!");

                var request = ReadRequest(networkStreem);

                Console.WriteLine(request);
                                              
                //connection.Close();
            }
        }

        private void WriteResponse(NetworkStream networkStreem, string messege)
        {
            var contentLength = Encoding.UTF8.GetByteCount(messege);

            var response = $@"HTTP/1.1 200 OK
Content-Type: text/plain; charset=UTF-8
Content-Length: {contentLength}

{messege}";

            var responseBytes = Encoding.UTF8.GetBytes(response);

            networkStreem.Write(responseBytes);

        }

        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLenght = 1024;
            var buffer = new byte[bufferLenght];

            var requestBuilder = new StringBuilder();
            var totalbytes = 0;
            do
            {
                var bytesRead = networkStream.Read(buffer, 0, bufferLenght);

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
