using SMS.ViewModels.Users;
using SMS.Views.Products;
using System.Collections.Generic;

namespace SMS.Service
{
    public interface IValidatorService
    {
        ICollection<string> RegisterValidator(RegesterFormModel model);

        ICollection<string> ProductValidator(ProductFormModel model);
    }
}
