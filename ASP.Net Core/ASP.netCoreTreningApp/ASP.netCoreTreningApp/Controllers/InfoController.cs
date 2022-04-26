using ASP.netCoreTreningApp.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ASP.netCoreTreningApp.Controllers
{
    //[AddHeaderActionFilter]
    public class InfoController : Controller
    {
        [AddHeaderActionFilter]
        public IActionResult Time()
        {
            return this.Content(DateTime.Now.ToLongTimeString());
        }

        public IActionResult Date()
        {
            return this.Content(DateTime.Now.ToLongDateString());
        }
    }
}
