using CarShop.ViewModels;
using CarShop.ViewModels.Issues;
using System.Collections.Generic;

namespace CarShop.Servises
{
    public interface IValidator
    {
        ICollection<string> RegisterValidator(RegesterFormModel model);

        ICollection<string> CarsValidator(AddCarsFormModel model);

        ICollection<string> ValidateIssue(AddIssueFormModel model);
    }
}
