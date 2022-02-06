using CarShop.ViewModels;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static CarShop.Data.Constants;

namespace CarShop.Servises
{
    
    public class Validator : IValidator
    {
        public ICollection<string> RegisterValidator(RegesterFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UsernameMinLenght || model.Username.Length > UserMaxLenght)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be betwen {UsernameMinLenght} and {UserMaxLenght} symbols.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailVaidation))
            {
                errors.Add($"Email '{model.Username}' is not valid e-mail address.");
            }

            if (model.Password.Length < UserPasswordMinLenght || model.Password.Length > UserMaxLenght)
            {
                errors.Add($"Password '{model.Password}' is not valid. It must be betwen {UserPasswordMinLenght} and {UserMaxLenght} symbols.");
            }

            if (model.UserType != UserTypeMechanic && model.UserType != UserTypeClient)
            {
                errors.Add($"User type '{model.UserType}' is not a valid type");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and password conformations should't be different.");
            }

            return errors;
        }
    }
}
