using ASP.netCoreTreningApp.Data;
using ASP.netCoreTreningApp.Views.ViewComponent;
using Microsoft.AspNetCore.Mvc;

namespace ASP.netCoreTreningApp.ViewComponents
{
    public class RegisterUserViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext data;

        public RegisterUserViewComponent(ApplicationDbContext data)
        {
            this.data = data;
        }

        public IViewComponentResult Invoke(string title)
        {
            var viewModel = new RegisteredUsersViewModel
            {
                Title = title,
                Users = this.data.Users.Count(),
            };

            return this.View(viewModel);
        }
    }
}
