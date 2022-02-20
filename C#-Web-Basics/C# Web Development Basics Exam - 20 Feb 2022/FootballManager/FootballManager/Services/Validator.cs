using FootballManager.Data;
using FootballManager.ViewModels.Players;
using FootballManager.ViewModels.Users;

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using static FootballManager.Data.Constants;

namespace FootballManager.Services
{
    internal class Validator : IValidator
    {
        private readonly FootballManagerDbContext data;
        private readonly IPasswordHasher passwordHasher;

        public Validator(FootballManagerDbContext data, IPasswordHasher passwordHasher)
        {
            this.data = data;
            this.passwordHasher = passwordHasher;
        }
        
        public ICollection<string> RegisterValidator(RegesterFormModel model)
        {
            var errors = new List<string>();

            if (model.Username == null || model.Username.Length < DefautMinLength || model.Username.Length > DefautMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be betwen {DefautMinLength} and {DefautMaxLength} symbols.");
            }

            if (model.Email == null || !Regex.IsMatch(model.Email, UserEmailVaidation))
            {
                errors.Add($"Email '{model.Email}' is not valid e-mail address.");
            }

            if (model.Password == null || model.Password.Length < DefautMinLength || model.Password.Length > DefautMaxLength)
            {
                errors.Add($"Password is not valid. It must be betwen {DefautMinLength} and {DefautMaxLength} symbols.");
            }

            if (model.Password == null || model.Password.Any(x => x == ' '))
            {
                errors.Add($"Password can not contain whitespaces.");
            }
            
            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and password conformations should't be different.");
            }

            if (this.data.Users.Any(u => u.Username == model.Username))
            {
                errors.Add($"User whit '{model.Username}' user name already exsist.");
            }

            if (this.data.Users.Any(u => u.Email == model.Email))
            {
                errors.Add($"User whit '{model.Email}' e-mail already exsist.");
            }

            return errors;
        }

        public ICollection<string> PlayerValidator(AddPlayerFormModel model, string userId)
        {
            var errors = new List<string>();

            if (model.FullName == null || model.FullName.Length < DefautMinLength || model.FullName.Length > FullNameMaxLength)
            {
                errors.Add($"Name '{model.FullName}' is not valid. It must be betwen {DefautMinLength} and {FullNameMaxLength} symbols.");
            }

            if (model.Position == null || model.Position.Length < DefautMinLength || model.Position.Length > DefautMaxLength)
            {
                errors.Add($"Position '{model.FullName}' is not valid. It must be betwen {DefautMinLength} and {DefautMaxLength} symbols.");
            }

            if (model.Speed < SpeedAndEnduranceMinValue || model.Speed > SpeedAndEnduranceMaxValue)
            {
                errors.Add($"Speed '{model.Speed}' is not valid. It must be betwen {SpeedAndEnduranceMinValue} and {SpeedAndEnduranceMaxValue}.");
            }

            if (model.Endurance < SpeedAndEnduranceMinValue || model.Endurance > SpeedAndEnduranceMaxValue)
            {
                errors.Add($"Endurance '{model.Speed}' is not valid. It must be betwen {SpeedAndEnduranceMinValue} and {SpeedAndEnduranceMaxValue}.");
            }

            if (model.Description == null ||  model.Description.Length > DescriptionMaxLength)
            {
                errors.Add($"Description '{model.Description}' is not valid. It must be betwen less than {DescriptionMaxLength} symbols.");
            }            

            return errors;
        }
    }
}

//•	Has Id – an int, Primary Key
//•	Has FullName – a string (required); min.length: 5, max.length: 80
//•	Has ImageUrl – a string (required)
//•	Has Position – a string (required); min.length: 5, max.length: 20
//•	Has Speed – a byte (required); cannot be negative or bigger than 10
//•	Has Endurance – a byte (required); cannot be negative or bigger than 10
//•	Has a Description – a string with max length 200 (required)
//•	Has UserPlayers collection

