using FootballManager.Services;
using FootballManager.ViewModels.Users;
using MyWebServer.Controllers;
using MyWebServer.Http;

using System;
using System.Linq;

namespace FootballManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IUserService userService;

        public UsersController(
            IValidator validator,
            IUserService userService)
        {
            this.validator = validator;
            this.userService = userService;
        }

        public HttpResponse Register()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegesterFormModel model)
        {
            var errors = validator.RegisterValidator(model);

            if (errors.Any())
            {
                Error(errors);
            }

            var user = userService.Create(model);

            try
            {
                userService.Update(user);
            }
            catch (Exception)
            {
                throw new Exception("Object is not added in the date base.");
            }

            return Redirect("/Users/login");
        }

        public HttpResponse Login()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Login(LoginFormModel model)
        {
            var userId = userService.GetUser(model);

            if (userId == null)
            {
                return Error($"Invalid username '{model.Username}' or password.");
            }

            this.SignIn(userId);

            return Redirect("/Players/All");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
