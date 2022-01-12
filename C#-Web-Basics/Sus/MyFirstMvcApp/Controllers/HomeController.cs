using BattleCards.ViewModels;
using SUS.HTTP;
using SUS.mvcFramework;
using System;
using System.Text;

namespace BattleCards.Controllers 
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.CurrentYear = DateTime.UtcNow.Year;
            viewModel.Message = "Welcome to Battle Cards";
            if (this.Request.Session.ContainsKey("about"))
            {
                viewModel.Message += "YOU WERE ON THE ABOUT PAGE!";
            }

            return this.View(viewModel);
        }

        public HttpResponse About()
        {
            this.Request.Session["about"] = "yes";
            return this.View();
        }        
    }
}
