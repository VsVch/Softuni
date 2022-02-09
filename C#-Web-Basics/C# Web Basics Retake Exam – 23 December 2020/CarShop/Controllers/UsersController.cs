using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Servises;
using CarShop.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace CarShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;
        private readonly IPasswordHasher passwordHasher;

        public UsersController(
            IValidator validator,
            ApplicationDbContext data,
            IPasswordHasher passwordHasher)
        {
            this.validator = validator;
            this.data = data;
            this.passwordHasher = passwordHasher;
        }

        public HttpResponse Register()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegesterFormModel model)
        {
            var result = validator.RegisterValidator(model);

            if (this.data.Users.Any(u => u.Username == model.Username))
            {
                result.Add($"User whit '{model.Username}' user name already exsist.");
            }

            if (this.data.Users.Any(u => u.Email == model.Email))
            {
                result.Add($"User whit '{model.Email}' e-mail already exsist.");
            }

            if (result.Any())
            {
                return Error(result);
            }

            var user = new User
            {
                Username = model.Username,
                Password = this.passwordHasher.HasPasword(model.Password),
                Email = model.Email,
                IsMechanic = model.UserType == Constants.UserTypeMechanic
            };

            data.Users.Add(user);

            data.SaveChanges();

            return Redirect("/Users/login");
        }

        public HttpResponse Login()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Login(LoginFormModel model)
        {

            var hashedPassword = this.passwordHasher.HasPasword(model.Password);

            var userId = this.data
                .Users
                .Where(u =>u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();
            
            if (userId == null)
            {
                return Error($"Invalid username '{model.Username}' or password.");
            }

            this.SignIn(userId);

            return Redirect("/Cars/All");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
