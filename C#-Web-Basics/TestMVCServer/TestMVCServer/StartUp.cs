using TestMVCServer.Server.Controller;
using TestMVCServer.Server;
using TestMVCServer.Controllers;

namespace TestMVCServer
{
    public class StartUp
    {
        public static async Task Main()
            => await new HttpServer(routes => routes
              .MapStaticFiles()
              .MapControllers())              
            .Start();
    }
}