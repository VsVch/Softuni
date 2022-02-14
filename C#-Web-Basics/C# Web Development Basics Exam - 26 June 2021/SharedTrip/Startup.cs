namespace SharedTrip
{
    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;

    using Controllers;
    using MyWebServer.Results.Views;
    using SharedTrip.Data;
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Service;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<ApplicationDbContext>()
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IValidatorService, ValidatorService>()
                    .Add<IPasswordHasher, PasswordHasher>())
                .WithConfiguration<ApplicationDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
