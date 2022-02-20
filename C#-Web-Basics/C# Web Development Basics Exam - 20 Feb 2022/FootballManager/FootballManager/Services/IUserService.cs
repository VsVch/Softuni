using FootballManager.Data.Models;
using FootballManager.ViewModels.Users;

namespace FootballManager.Services
{
    public interface IUserService
    {
        User Create(RegesterFormModel model);

        void Update(User user);

        string GetUser(LoginFormModel model);

        User GetUserById(string id);
    }
}
