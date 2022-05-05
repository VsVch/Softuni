using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASP.netCoreTreningApp.Controllers
{
    public class IdentityTestController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public IdentityTestController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<ActionResult> Create()
        {
            var user = new IdentityUser
            {
                Email = "sand@abv.bg",
                UserName = "sand",
                EmailConfirmed = true,
                PhoneNumber = "09876543210"
            };

            var result = await this.userManager.CreateAsync(user, "123456");
            return this.Json(result);
        }

        public async Task<IActionResult> Login()
        {
            var result = await this.signInManager.PasswordSignInAsync("sand@abv.bg", "123456", true, true);
            return this.Json(result);
        }

        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return this.Redirect("/");
        }

        public async Task<IActionResult> WhoAmI()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            return this.Json(user);
        }

        public async Task<IActionResult> AddClame()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var result = await this.userManager.AddClaimAsync(user, new Claim("state", "California"));

            return this.Json(result);
        }

        public async Task<IActionResult> GetClame()
        {
            var clame = this.User.FindFirst("state");
            return this.Json(clame.Value);
        }
    }
}
