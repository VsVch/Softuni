using System.Collections.Generic;
using System.Linq;

using SMS.ViewModels.Users;
using System.Text.RegularExpressions;

using static SMS.Service.Constants;
using SMS.Views.Products;

namespace SMS.Service
{
    public class ValidatorService : IValidatorService
    {
        public ICollection<string> RegisterValidator(RegesterFormModel model)
        {
            var errors = new List<string>();

            if (model.Username == null || model.Username.Length < UsernameMinLenght || model.Username.Length > DefautMaxValue)
            {
                errors.Add($"User name '{model.Username}' is not valid. It must be betwen {UsernameMinLenght} and {DefautMaxValue} symbols.");
            }

            if (model.Email == null || !Regex.IsMatch(model.Email, UserEmailVaidation))
            {
                errors.Add($"Email '{model.Email}' is not valid e-mail address.");
            }

            if (model.Password == null || model.Password.Length < UserPasswordMinLenght || model.Password.Length > DefautMaxValue)
            {
                errors.Add($"Password is not valid. It must be betwen {UserPasswordMinLenght} and {DefautMaxValue} symbols.");
            }

            if (model.Password == null || model.Password.Any(x => x == ' '))
            {
                errors.Add($"Password can not contain whitespaces.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and password conformations should not be different.");
            }

            return errors;
        }

        public ICollection<string> ProductValidator(ProductFormModel model)
        {
            var errors = new List<string>();

            if (model.Name == null || model.Name.Length < ProductMinValue || model.Name.Length > DefautMaxValue)
            {
                errors.Add($"Name '{model.Name}' is not valid. It must be betwen {ProductMinValue} and {DefautMaxValue} symbols.");
            }

            if (model.Price < PriceMinValue || model.Price > PriceMaxValue)
            {
                errors.Add($"Price '{model.Name}' is not valid. It must be betwen {PriceMinValue} and {PriceMaxValue}.");
            }

            return errors;
        }
    }
}
//•	Has an Id – a string, Primary Key
//•	Has a Name – a string with min length 4 and max length 20 (required)
//•	Has Price – a decimal (in range 0.05 – 1000)
//•	Has a Cart – a Cart object
