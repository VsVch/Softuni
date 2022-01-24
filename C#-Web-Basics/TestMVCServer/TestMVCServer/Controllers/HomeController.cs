using TestMVCServer.Server.Controller;
using TestMVCServer.Server.Http;

namespace TestMVCServer.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(HttpRequest request)
            : base(request)
        {
        }

        public HttpResponse Index() => Text("Hello from Sand!");

        public HttpResponse LocalRedirect() => Redirect("/Cats");

        public HttpResponse ToSoftUni() => Redirect("https://softuni.bg");
    }
}
