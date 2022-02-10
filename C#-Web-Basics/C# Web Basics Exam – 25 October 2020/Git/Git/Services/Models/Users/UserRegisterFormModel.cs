using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services.Models
{
    public class UserRegisterFormModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}

//username: client
//email: sandoki @abv.bg
//password: 123456
//confirmPassword: 123456
