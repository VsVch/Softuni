using Git.Services.Models;
using Git.Services.Models.Repository;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IUsersService
    {
        public ICollection<string> ValidateUsersPropertyes(UserRegisterFormModel model);      

        bool IsEmailAvailable(string email);

        string GetUserId(UserLoginFormModel model);

        bool IsUsernameAvailable(string username);
    }
}
