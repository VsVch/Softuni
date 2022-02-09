using CarShop.ViewModels;
using CarShop.ViewModels.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using static CarShop.Data.Constants;

namespace CarShop.Servises
{
    
    public class Validator : IValidator
    {      
        public ICollection<string> RegisterValidator(RegesterFormModel model)
        {
            var errors = new List<string>();

            if (model.Username == null || model.Username.Length < UsernameMinLenght || model.Username.Length > UserMaxLenght)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be betwen {UsernameMinLenght} and {UserMaxLenght} symbols.");
            }

            if (model.Email == null || !Regex.IsMatch(model.Email, UserEmailVaidation))
            {
                errors.Add($"Email '{model.Email}' is not valid e-mail address.");
            }

            if (model.Password == null || model.Password.Length < UserPasswordMinLenght || model.Password.Length > UserMaxLenght)
            {
                errors.Add($"Password is not valid. It must be betwen {UserPasswordMinLenght} and {UserMaxLenght} symbols.");
            }

            if (model.Password == null || model.Password.Any(x => x == ' '))
            {
                errors.Add($"Password can not contain whitespaces.");
            }

            if (model.UserType == null || model.UserType != UserTypeMechanic && model.UserType != UserTypeClient)
            {
                errors.Add($"User type '{model.UserType}' is not a valid type.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and password conformations should't be different.");
            }

            return errors;
        }

        public ICollection<string> CarsValidator(AddCarsFormModel carModel)
        {
            var errors = new List<string>();            

            if (carModel.Model == null || carModel.Model.Length < CarModelMinLenght || carModel.Model.Length > CarModelMaxLenght)
            {
                errors.Add($"Model '{carModel.Model}' is not valid. It must be betwen {CarModelMinLenght} and {CarModelMaxLenght} symbols.");
            }

            if (carModel.Year < YearMinValue)
            {
                errors.Add($"Year '{carModel.Year}' can not be less than {YearMinValue}");
            }

            if (carModel.PlateNumber == null || !Regex.IsMatch(carModel.PlateNumber, plateNumberRegex))
            {
                errors.Add($"Plate number is not in format 'XX0000XX'.");
            }

            if (carModel.Image == null || !Uri.IsWellFormedUriString(carModel.Image, UriKind.Absolute))
            {
                errors.Add($"Imag '{carModel.Image}' is not a valid format.");
            }

            return errors;
        }

        public ICollection<string> ValidateIssue(AddIssueFormModel model)
        {
            var errors = new List<string>();

            if (model.CarId == null)
            {
                errors.Add($"Car ID can not be empty.");
            }

            if (model.Description.Length < IssueMinDescription)
            {
                errors.Add($"Model '{model.Description}' is not valid. It must be more than {IssueMinDescription} symbols.");
            }

            return errors;
        }
    }
}
