using SUS.HTTP;
using SUS.mvcFramework;
using System.IO;
using System.Text;


namespace BattleCards.Controllers
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
