using MyWebServer;
using FootballManager.Data;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using Microsoft.EntityFrameworkCore;
using FootballManager.Services;

using System.Threading.Tasks;

namespace FootballManager
{
    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                .Add<FootballManagerDbContext>()
                .Add<IViewEngine, CompilationViewEngine>()
                .Add<IValidator, Validator>()
                .Add<IPasswordHasher, PasswordHasher>()
                .Add<IUserService, UserService>()
                .Add<IPlayerService, PlayerService>())
                .WithConfiguration<FootballManagerDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
