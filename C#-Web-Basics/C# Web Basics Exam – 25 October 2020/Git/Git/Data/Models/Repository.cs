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

        public User User { get; set; }

        public IEnumerable<Commit> Commits { get; set; }
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Name – a string with min length 3 and max length 10 (required)
//•	Has a CreatedOn – a datetime (required)
//•	Has a IsPublic – bool (required)
//•	Has a OwnerId – a string
//•	Has a Owner – a User object
//•	Has Commits collection – a Commit type
