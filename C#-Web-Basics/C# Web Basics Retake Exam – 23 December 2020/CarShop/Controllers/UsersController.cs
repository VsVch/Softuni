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
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegesterFormModel model)
        {
            var result = validator.RegisterValidator(model);

            if (result.Any())
            {
                return Error(result);
            }         

            var user = new User
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
                IsMechanic = model.UserType == Constants.UserTypeMechanic
            };

            data.Users.Add(user);

            data.SaveChanges();

            return this.Redirect("/Users/login");
        }

        public HttpResponse Login()
        {
            return this.View();
        }
    }
}
