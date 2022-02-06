using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static CarShop.Data.Constants;

namespace CarShop.Data.Models
{
    public class Car
    {
       
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(CarModelMaxLenght)]
        public string Model { get; set; }

        public int Year { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        public string PlateNumber { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public User User { get; set; }

        public IEnumerable<Issue> Issues { get; set; } = new HashSet<Issue>();


    }
}
