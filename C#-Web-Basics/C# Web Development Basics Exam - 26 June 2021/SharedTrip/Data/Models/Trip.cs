using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static SharedTrip.Data.Constants;

namespace SharedTrip.Models
{
    public class Trip
    {
        public Trip()
        {
            this.UserTrips = new HashSet<UserTrip>();
        }

        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string StartPoint { get; set; }

        [Required]
        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        [MaxLength(TripSeatsMaxValue)]
        public int Seats { get; set; }

        [Required]
        [MaxLength(TripDescriptionMaxValue)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public IEnumerable<UserTrip> UserTrips { get; set; }
    }
}
//•	Has an Id – a string, Primary Key
//•	Has a StartPoint – a string (required)
//•	Has a EndPoint – a string (required)
//•	Has a DepartureTime – a datetime (required) 
//•	Has a Seats – an integer with min value 2 and max value 6 (required)
//•	Has a Description – a string with max length 80 (required)
//•	Has a ImagePath – a string
//•	Has UserTrips collection – a UserTrip type
