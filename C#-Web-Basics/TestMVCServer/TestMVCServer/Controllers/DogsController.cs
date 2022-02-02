using TestMVCServer.Models.Animals;
using TestMVCServer.Server.Controller;
using TestMVCServer.Server.Http;

namespace TestMVCServer.Controllers
{
    public class DogsController : Controller
    {
       
        [HttpGet]
        public HttpResponse Create() => View();

        [HttpPost]
        public HttpResponse Create(DogFormModel model)
            => Text($"Dog: {model.Name} - {model.Age} - {model.Breed}");
    }
}
