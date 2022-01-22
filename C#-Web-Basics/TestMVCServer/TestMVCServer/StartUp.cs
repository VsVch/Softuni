using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TestMVCServer.Server;

namespace TestMVCServer // Note: actual namespace depends on the project name.
{
    public class StartUp
    {
        public static async Task Main(string[] args)
        {
            var ipAddres = IPAddress.Parse("127.0.0.1");
            var port = 12345;
            HttpServer httpServer = new HttpServer(ipAddres, port);
            await httpServer.Start();
        }
    }
}