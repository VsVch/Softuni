using ASP.netCoreTreningApp.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASP.netCoreTreningApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestJwtController : Controller
    {
        private readonly IOptions<JwtSettings> jwtSettings;

        public TestJwtController(IOptions<JwtSettings> jwtSettings)
        {
            this.jwtSettings = jwtSettings;
        }

        public ActionResult<string> WhoAmI()
        {
            return this.User.Identity.Name;
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public ActionResult<string> Login(LoginInputModel input)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.jwtSettings.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor 
            { 
                Subject = new ClaimsIdentity(new Claim []
                {
                    new Claim(ClaimTypes.Name, "Sand"),
                    new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
                })
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenAsString = tokenHandler.WriteToken(token);

            return tokenAsString;
        }
    }

    public class LoginInputModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
