using ASP.netCoreTreningApp.ViewModel.Recipes;
using Microsoft.AspNetCore.Mvc;

namespace ASP.netCoreTreningApp.Controllers
{
       
    public class RecipesController : Controller
    {
        public IActionResult Add(RecipesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Json(this.ModelState);
            }

            return this.Json(model);
        }
    }
}
