using TestMVCServer.Server.Controller;
using TestMVCServer.Server.Http;

namespace TestMVCServer.Controllers
{
    public class HomeController : Controller
    {
               public HttpResponse Index() => Text("Hello from Sand!");

        public HttpResponse LocalRedirect() => Redirect("/Animals/Cats");

        public HttpResponse StaticFiles() => View();

        public HttpResponse ToSoftUni() => Redirect("https://softuni.bg");

        public HttpResponse Error() => throw new InvalidOperationException("Invalid action!");
    }
}
