using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static Git.Data.Constants;


namespace Git.Data.Models
{
    public class User
    {
        public User()
        {
            Commits = new HashSet<Commit>();
        }

        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DefaultMaxLenght)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        public string Password { get; set; }

        public IEnumerable<Repository> Repositories { get; set; }

        public IEnumerable<Commit> Commits { get; set; }
    }
}

