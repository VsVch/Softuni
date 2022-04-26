using ASP.netCoreTreningApp.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace ASP.netCoreTreningApp.Controllers
{
    public class RecipesViewModel 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime FirstCooked { get; set; }

        //[ModelBinder(typeof(ExtractYearModelBinder))]
        public int Year { get; set; }

        public string Description { get; set; }
    }

    public class RecipesController : Controller
    {
        public IActionResult Add(
            
            RecipesViewModel model)
        {
            return this.Json(model);
        }
    }
}
