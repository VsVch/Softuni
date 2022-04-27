using ASP.netCoreTreningApp.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace ASP.netCoreTreningApp.ViewModel.Recipes
{
    public class RecipesViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string? Name { get; set; }

        [CurrentYearMaxValue(1900)]
        public DateTime FirstCooked { get; set; }

        public int CookingTime { get; set; }

        //[ModelBinder(typeof(ExtractYearModelBinder))]
        public int Year { get; set; }

        public string? Description { get; set; }

        public IEnumerable<IngredientViewModel>? Ingredients { get; set; }
    }
}
