using SUS.HTTP;
using SUS.mvcFramework;
using System.IO;
using System.Text;


namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Register(HttpRequest arg)
        {         
            return this.View();
        }

        public HttpResponse Login(HttpRequest request)
        {           
            return this.View();
        }
    }
}
