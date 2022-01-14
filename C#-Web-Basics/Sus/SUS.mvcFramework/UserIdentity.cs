using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUS.mvcFramework
{
    public class UserIdentity
    {
        public UserIdentity()
        {
            this.Id = Guid.NewGuid().ToString();
        }   
        public string Id { get; set; }

        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        
    }
}
