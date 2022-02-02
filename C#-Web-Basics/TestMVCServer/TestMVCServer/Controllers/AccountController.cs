using TestMVCServer.Server.Controller;
using TestMVCServer.Server.Http;
using TestMVCServer.Server.Results;

namespace TestMVCServer.Controllers
{
    public class AccountController : Controller
    {
       
        public HttpResponse Login() 
        {
            var someUserid = "MyUserId";
            this.SignIn(someUserid);

            return Text("User authenticated");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Text("User signed out!");
        }

        public HttpResponse AuthenticationCheck()
        {
            if (this.User.IsAuthenticated)
            {
                return Text($"Authenticated user:{this.User.Id}");
            }

            return Text($"User is not authenticated");
        }
        
        [Authorize]
        public HttpResponse AuthorizationCheck()
        {
            return Text($"Current user: {this.User.Id}");
        }

        public  HttpResponse CookiesCheck()
        {
            const string cookieName = "My-Cookie";

            if (this.Request.Cookies.ContainsKey(cookieName))
            {
                var cookie = this.Request.Cookies[cookieName];

                return Text($"Cookies already exist - {cookie}");
            }

            this.Response.AddCookie("My-Cookie", "My-Value");
            this.Response.AddCookie("My-Second-Cookie", "My-Second-Value");

            return Text("Cookies set!");
        }

        public HttpResponse SessionCheck()
        {
            var currendtDateKey = "CurrentDate";

            if (this.Request.Session.ContainsKey(currendtDateKey))
            {
                var currentdate = this.Request.Session[currendtDateKey];

                return Text($"Stored date: {currentdate}");
            }

            this.Request.Session[currendtDateKey] = DateTime.UtcNow.ToString();

            return Text("Current date stored!");
        }
    }
}
