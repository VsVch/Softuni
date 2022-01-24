
using TestMVCServer.Server.Controller;
using TestMVCServer.Server;
using TestMVCServer.Controllers;

namespace TestMVCServer                                 
{
    public class StartUp
    {
        public static async Task Main()
            => await new HttpServer(routes => routes
              .MapGet<HomeController>("/", c => c.Index())
              .MapGet<HomeController>("/ToCats", c => c.LocalRedirect())
              .MapGet<HomeController>("/Softuni", c => c.ToSoftUni())
              .MapGet<AnimalsController>("/Cats", c => c.Cats())
              .MapGet<AnimalsController>("/Dogs", c => c.Dogs()))
            .Start();

    }
}