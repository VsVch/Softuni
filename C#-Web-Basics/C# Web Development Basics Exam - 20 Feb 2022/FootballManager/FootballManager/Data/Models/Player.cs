using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static FootballManager.Data.Constants;

namespace FootballManager.Data.Models
{
    public class Player
    {
        public Player()
        {
            this.UserPlayers = new HashSet<UserPlayer>();
        }

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(DefautMaxLength)]
        public string Position { get; set; }

        [Range(SpeedAndEnduranceMinValue, SpeedAndEnduranceMaxValue)]
        public byte Speed { get; set; }

        [Range(SpeedAndEnduranceMinValue, SpeedAndEnduranceMaxValue)]
        public byte Endurance { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public IEnumerable<UserPlayer> UserPlayers { get; set; }
    }
}

//•	Has Id – an int, Primary Key
//•	Has FullName – a string (required); min.length: 5, max.length: 80
//•	Has ImageUrl – a string (required)
//•	Has Position – a string (required); min.length: 5, max.length: 20
//•	Has Speed – a byte (required); cannot be negative or bigger than 10
//•	Has Endurance – a byte (required); cannot be negative or bigger than 10
//•	Has a Description – a string with max length 200 (required)
//•	Has UserPlayers collection
