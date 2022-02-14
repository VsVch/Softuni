using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SharedTrip.ViewModels.Trips;
using SharedTrip.ViewModels.User;

using static SharedTrip.Data.Constants;

namespace SharedTrip.Service
{
    public class ValidatorService : IValidatorService
    {
        public ICollection<string> RegisterValidator(RegesterFormModel model)
        {
            var errors = new List<string>();

            if (model.Username == null || model.Username.Length < UsernameMinLenght || model.Username.Length > DefautMaxValue)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be betwen {UsernameMinLenght} and {DefautMaxValue} symbols.");
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
                errors.Add($"Password and password conformations should't be different.");
            }

            return errors;
        }

        public ICollection<string> TripsValidator(AddTripsFormModel model)
        {
            var errors = new List<string>();

            if (model.Seats < TripSeatsMinValue || model.Seats > TripSeatsMaxValue)
            {
                errors.Add($"Number of seats '{model.Seats}' is not valid. It must be betwen {TripSeatsMinValue} and {TripSeatsMaxValue}.");
            }
           
            if (model.Description == null || model.Description.Length > TripDescriptionMaxValue)
            {
                errors.Add($"Description is not valid. It must be less than {TripDescriptionMaxValue}.");
            }

            if (string.IsNullOrWhiteSpace(model.StartPoint) || string.IsNullOrWhiteSpace(model.EndPoint))
            {
                errors.Add($"Fild can't be empty value.");
            }

            return errors;
        }
    }
}
