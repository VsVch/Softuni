using SUS.HTTP;
using SUS.mvcFramework;
using System.IO;
using System.Text;


namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Register()
        {         
            return this.View();
        }

        public HttpResponse Login()
        {           
            return this.View();
        }

        //[HttPost]
        //public HttpRequest DoLogin()
        //{
        //    return Redirect("/");
        //}
    }
}
