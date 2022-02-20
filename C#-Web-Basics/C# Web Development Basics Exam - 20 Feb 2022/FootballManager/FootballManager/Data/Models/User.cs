using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static FootballManager.Data.Constants;

namespace FootballManager.Data.Models
{
    public class User
    {
        public User()
        {
            this.UserPlayers = new HashSet<UserPlayer>();
        }

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DefautMaxLength)]
        public string Username { get; set; }

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public IEnumerable<UserPlayer> UserPlayers { get; set; }
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Username – a string with min length 5 and max length 20 (required)
//•	Has an Email – a string with min length 10 and max length 60 (required)
//•	Has a Password – a string with min length 5 and max length 20 (before hashed)  -no max length required for a hashed password in the database (required)
//•	Has UserPlayers collection
