using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Data;
using SMS.Data.Models;
using SMS.Service;
using SMS.ViewModels.Users;
using System.Linq;

namespace SMS.Controllers
{
    public class UsersController : Controller
    {
        private readonly SMSDbContext data;
        private readonly IValidatorService validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly IDataHelper helper;

        public UsersController(SMSDbContext data,
            IValidatorService validator,
            IPasswordHasher passwordHasher,
            IDataHelper helper)
        {
            this.data = data;
            this.validator = validator;
            this.passwordHasher = passwordHasher;
            this.helper = helper;
        }

        public HttpResponse Login() => View();


        [HttpPost]
        public HttpResponse Login(LoginFormModel model)
        {
            var hashedPassword = this.passwordHasher.HashPasword(model.Password);

            var user = this.data
                .Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)                
                .FirstOrDefault();

            if (user.Id == null)
            {
                return Error($"Invalid username or password.");
            }

            var cartProducts = helper.GetPdoducts(user.CartId);

            this.data.RemoveRange(cartProducts);

            this.data.SaveChanges();

            this.SignIn(user.Id);

            return Redirect("/");
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

            var cart = new Cart
            {
            };

            var user = new User
            {
                Username = model.Username,
                Password = this.passwordHasher.HashPasword(model.Password),
                Email = model.Email,
                Cart = cart
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