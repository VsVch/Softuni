using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Models;
using SharedTrip.Service;
using SharedTrip.ViewModels.User;

using System.Linq;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidatorService validator;
        private readonly IPasswordHasher passwordHasher;

        public UsersController(ApplicationDbContext data, IValidatorService validator, IPasswordHasher passwordHasher)
        {
            this.data = data;
            this.validator = validator;
            this.passwordHasher = passwordHasher;
        }

        public HttpResponse Login() => View();


        [HttpPost]
        public HttpResponse Login(LoginFormModel model)
        {
            var hashedPassword = this.passwordHasher.HashPasword(model.Password);

            var userId = this.data
                .Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return Error($"Invalid username or password.");
            }

            this.SignIn(userId);

            return Redirect("/Trips/All");
        }

        public HttpResponse Register() => View();


        [HttpPost]
        public HttpResponse Register(RegesterFormModel model)
        {
            var errors = validator.RegisterValidator(model);

            if (this.data.Users.Any(u => u.Username == model.Username) ||
              this.data.Users.Any(u => u.Email == model.Email))
            {
                errors.Add($"User or e-mail already exsist.");
            }

            if (errors.Any())
            {
                return Error(errors);
            }
            var user = new User
            {                
                Username = model.Username,
                Password = this.passwordHasher.HashPasword(model.Password),
                Email = model.Email,               
            };

            data.Users.Add(user);

            data.SaveChanges();

            return Redirect("/Users/login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
