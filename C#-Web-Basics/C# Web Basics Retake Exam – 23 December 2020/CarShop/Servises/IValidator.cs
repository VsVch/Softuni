using CarShop.ViewModels;
using System.Collections.Generic;

namespace CarShop.Servises
{
    public interface IValidator
    {
        ICollection<string> RegisterValidator(RegesterFormModel model);
    }
}
