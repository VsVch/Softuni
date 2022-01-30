using TestMVCServer.Server.Controller;
using TestMVCServer.Server.Http;
using TestMVCServer.Server.Results;

namespace TestMVCServer.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(HttpRequest request)
            : base(request)
        {
        }

        public  HttpResponse ActionWhitCookies()
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

        public HttpResponse ActionWhitSession()
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
