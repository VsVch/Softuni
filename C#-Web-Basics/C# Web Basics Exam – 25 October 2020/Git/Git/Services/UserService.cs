using Git.Data;
using Git.Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using static Git.Data.Constants;

namespace Git.Services
{
    public class UserService : IUsersService
    {
        private readonly ApplicationDbContext data;
        private readonly IPasswordHasher hasher;

        public UserService(ApplicationDbContext data, IPasswordHasher hasher)
        {
            this.data = data;
            this.hasher = hasher;
        }

        public ICollection<string> ValidateUsersPropertyes(UserRegisterFormModel model)
        {
            var errors = new List<string>();

            if (model.Username == null ||
                model.Username.Length < UsernameMinLenght ||
                model.Username.Length > DefaultMaxLenght)
            {
                errors.Add($"User name '{model.Username}' is not valid. It must be between {UsernameMinLenght} and {DefaultMaxLenght}.");
            }

            if (model.Email == null || !Regex.IsMatch(model.Email, UsernameEmailValidator))
            {
                errors.Add($"'{model.Email}' is not valid format e-mail.");
            }

            if (model.Password == null ||
                model.Password.Length < PasswordMinLenght ||
                model.Password.Length > DefaultMaxLenght)
            {
                errors.Add($"User name '{model.Password}' is not valid. It must be between {PasswordMinLenght} and {DefaultMaxLenght}.");
            }

            if (model.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contains whitespaces.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and password confurmation don't mach.");
            }

            return errors;
        }      

        public string GetUserId(UserLoginFormModel model)
        {
            var hashedPassword = hasher.HashPasword(model.Password);

            var user = this.data.Users.FirstOrDefault(x => x.Username == model.Username && x.Password == hashedPassword);

            return user != null ? user.Id : null;
        }       

        public bool IsEmailAvailable(string email)
        {
            return this.data.Users.Any(u => u.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
           return this.data.Users.Any(u => u.Username == username);
        }       
    }
}
