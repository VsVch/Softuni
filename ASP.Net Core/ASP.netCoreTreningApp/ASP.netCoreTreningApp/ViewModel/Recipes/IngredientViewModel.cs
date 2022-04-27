using System.ComponentModel.DataAnnotations;

namespace ASP.netCoreTreningApp.ViewModel.Recipes
{
    public class IngredientViewModel : IValidatableObject
    {
        public int PreaprationTime { get; set; }

        public int CookingTime { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.PreaprationTime > this.CookingTime)
            {
                yield return new ValidationResult("Prep time can be more than cooking time");

            }

            if (this.PreaprationTime + this.CookingTime > 2.5 * 24 * 60)
            {
                yield return new ValidationResult("To long cooking time. ");
            }
        }
    }
}
