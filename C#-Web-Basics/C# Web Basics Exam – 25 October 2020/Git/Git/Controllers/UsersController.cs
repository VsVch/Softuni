using Git.Data;
using Git.Data.Models;
using Git.Services;
using Git.Services.Models;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService service;
        private readonly ApplicationDbContext data;
        private readonly IPasswordHasher hasher;

        public UsersController(IUsersService service,
            ApplicationDbContext data,
            IPasswordHasher hasher)
        {
            this.service = service;
            this.data = data;
            this.hasher = hasher;
        }

        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(UserRegisterFormModel model)
        {
            var errors = service.ValidateUsersPropertyes(model);

            if (service.IsUsernameAvailable(model.Username) ||
                service.IsEmailAvailable(model.Email))
            {
                errors.Add($"User name or email already exist.");
            }

            if (errors.Any())
            {
                return Error(errors);
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = hasher.HasPasword(model.Password),
            };

            this.data.Users.Add(user);

            this.data.SaveChanges();            

            return Redirect("/Users/login");
        }

        public HttpResponse Login() => View();

        [HttpPost]
        public HttpResponse Login(UserLoginFormModel model)
        {
            var userId = service.GetUserId(model);

            if (userId == null)
            {
                return Error($"Invalid username '{model.Username}' or password.");
            }

            SignIn(userId);

            return Redirect("/Repositories/All");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
