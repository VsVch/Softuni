using MyWebServer.Controllers;
using MyWebServer.Http;

using SMS.Data;
using SMS.Data.Models;
using SMS.ViewModels.Products;
using SMS.Service;

using System.Linq;

namespace SMS.Controllers
{

    public class HomeController : Controller
    {
        private readonly SMSDbContext data;
        private readonly IDataHelper helper;

        public HomeController(SMSDbContext data, IDataHelper helper)
        {
            this.data = data;
            this.helper = helper;
        }


        [Authorize]
        public HttpResponse IndexLoggedIn()
        {
            var user = helper.GetUserById(User.Id);

            if (user == null)
            {
                return NotFound();
            }            
                        
            var products = helper.GetUserProductsData(user.Username);

            return View(products);
        }

        public HttpResponse Index()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Home/IndexLoggedIn");
            }
            return this.View();
        }
    }
}