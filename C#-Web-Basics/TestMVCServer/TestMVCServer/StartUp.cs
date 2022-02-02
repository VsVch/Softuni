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
              ////.MapGet<HomeController>("/", c => c.Index())
              //.MapGet<HomeController>("/ToCats", c => c.LocalRedirect())
              //.MapGet<HomeController>("/Softuni", c => c.ToSoftUni())
              //.MapGet<HomeController>("/StaticFiles", c => c.StaticFiles())
              //.MapGet<HomeController>("/Error", c => c.Error())
              //.MapGet<AnimalsController>("/Cats", c => c.Cats())
              //.MapGet<AnimalsController>("/Dogs", c => c.Dogs())
              //.MapGet<AnimalsController>("/Bunnies", c => c.Bunnies())
              //.MapGet<AnimalsController>("/Turtles", c => c.Turtles())
              //.MapGet<AccountController>("/Cookies", c => c.CookiesCheck())
              //.MapGet<AccountController>("/Session", c => c.SessionCheck())
              //.MapGet<AccountController>("/Logout", c => c.Logout())
              //.MapGet<AccountController>("/Login", c => c.Login())
              //.MapGet<AccountController>("/Authenticated", c => c.AuthenticatedCheck())
              //.MapGet<CatsController>("/Cats/Create", c => c.Create())
              //.MapPost<CatsController>("/Cats/Save", c => c.Save()))              
            .Start();
    }
}