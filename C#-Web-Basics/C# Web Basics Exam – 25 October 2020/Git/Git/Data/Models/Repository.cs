using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static Git.Data.Constants;

namespace Git.Data.Models
{
    public class Repository
    {
        public Repository()
        {
            Commits = new HashSet<Commit>();
        }

        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(RepositoryMaxLenght)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsPublic { get; set; }

        public string OwnerId { get; set; }

        public User Owner { get; set; }

        public User User { get; set; }

        public IEnumerable<Commit> Commits { get; set; }
    }
}

