using ASP.netCoreTreningApp.Data;
using ASP.netCoreTreningApp.Service;
using ASP.netCoreTreningApp.Views.ViewComponent;
using Microsoft.AspNetCore.Mvc;

namespace ASP.netCoreTreningApp.ViewComponents
{
    public class RegisterUserViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext data;
        private readonly IInstanceCounter instanceCounter;

        public RegisterUserViewComponent(ApplicationDbContext data,
            IInstanceCounter instanceCounter)
        {
            this.data = data;
            this.instanceCounter = instanceCounter;
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
