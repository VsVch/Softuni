using FootballManager.Data;
using FootballManager.Data.Models;
using FootballManager.ViewModels.Users;
using System.Linq;

namespace FootballManager.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher passwordHasher;
        private readonly FootballManagerDbContext data;

        public UserService(IPasswordHasher passwordHasher, FootballManagerDbContext data)
        {
            this.passwordHasher = passwordHasher;
            this.data = data;
        }
        public User Create(RegesterFormModel model)
        {
            var user = new User
            {
                Username = model.Username,
                Password = this.passwordHasher.HashPasword(model.Password),
                Email = model.Email,                
            };

            return user;
        }

        public string GetUser(LoginFormModel model)
        {
            var hashedPassword = this.passwordHasher.HashPasword(model.Password);

            var userId = this.data
                .Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            return userId;
        }

        public User GetUserById(string id)
        {
            var user = this.data.Users.FirstOrDefault(u => u.Id == id);

            return user;
        }

        public void Update(User user)
        {
            data.Users.Add(user);

            data.SaveChanges();
        }
    }
}
