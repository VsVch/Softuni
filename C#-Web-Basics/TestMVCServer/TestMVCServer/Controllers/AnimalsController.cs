using TestMVCServer.Server.Controller;
using TestMVCServer.Server.Http;

namespace TestMVCServer.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly HttpRequest request;

        public AnimalsController(HttpRequest request)
            : base(request)
        {
        }

        public HttpResponse Cats()
        {
            const string nameKey = "Name";

            var query = this.Request.Query;

            var catName = query.ContainsKey(nameKey)
                ? query[nameKey]
                : "the Cats";

            var result = $"<h1>Hello from {catName}!</h1>";

            return Html(result);            
        }

        public HttpResponse Dogs() => View();

        public HttpResponse Bunnies() => View("Rabbits");

        public HttpResponse Turtles() => View("Animals/Wild/Turtles");
    }
}
