using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EfCodeFirstDemo.Models
{
    public class Question
    {
        public Question()
        {
            Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        public DateTime CreateOn { get; set; }

        public string Author { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
