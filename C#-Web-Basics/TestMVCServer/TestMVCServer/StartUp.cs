using TestMVCServer.Server;
using TestMVCServer.Server.Response;
using TestMVCServer.Server.Responses;

namespace TestMVCServer // Note: actual namespace depends on the project name.
{
    public class StartUp
    {
        public static async Task Main(string[] args)
            =>  await new HttpServer( routes => routes
                .MapGet("/", new TextResponse("Hello from Sand"))
                .MapGet("/Cats", new HtmlResponse("<h1>Hello from Cats!</h1>"))
                .MapGet("/Dogs", new HtmlResponse("<h1>Hello from Dogs!</h1>")))
            .Start();
        
    }
}