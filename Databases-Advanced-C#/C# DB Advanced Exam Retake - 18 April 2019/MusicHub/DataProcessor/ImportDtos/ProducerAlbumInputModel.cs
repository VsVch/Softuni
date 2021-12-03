using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ProducerAlbumInputModel
    {
        [Required]
        [StringLength(30 , MinimumLength = 3)]
        public string Name { get; set; }

        [RegularExpression(@"[A-Z][a-z]{2,} [A-Z][a-z]{2,}")]
        public string Pseudonym { get; set; }

        [RegularExpression(@"\+359 \d{3} \d{3} \d{3}")]
        public string PhoneNumber { get; set; }

        public ICollection<AlbumInputModel> Albums { get; set; }
    }

    //•	Id – integer, Primary Key
    //•	Name– text with min length 3 and max length 30 (required)
    //•	Pseudonym – text, consisting of two words separated with space and each word must start with one upper letter and continue with many lower-case letters (Example: "Bon Jovi")
    //•	PhoneNumber – text, consisting only of three groups (separated by space) of three digits and starting always with "+359" (Example: "+359 887 234 267")
    //•	Albums – collection of type Album

    public class AlbumInputModel
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        
        public string ReleaseDate { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	Name – text with min length 3 and max length 40 (required)
//•	ReleaseDate – Date(required)
//•	Price – calculated property(the sum of all song prices in the album)
//•	ProducerId – integer foreign key
//•	Producer – the album’s producer
//•	Songs – collection of all songs in the album 


//[
//  {
//    "Name": "Invalid",
//    "Pseudonym": "Rog Coiley",
//    "PhoneNumber": "(105) 9339880",
//    "Albums": [
//      {
//        "Name": "Sweetbitter",
//        "ReleaseDate": "07/1/2018"
//      },
//      {
//               "Name": "Emergency",
//        "ReleaseDate": "16/09/2018"
//      }
//    ]
//  },

