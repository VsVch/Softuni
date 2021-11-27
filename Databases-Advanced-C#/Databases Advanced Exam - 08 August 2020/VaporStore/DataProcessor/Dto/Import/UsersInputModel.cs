using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class UsersInputModel
    {
        [Required]
        [RegularExpression("[A-Z]{1}[a-z]{2,} [A-Z]{1}[a-z]{2,}")]        
        public string FullName { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        public ICollection<CardInputModel> Cards { get; set; }
    }

    public class CardInputModel
    {
        [Required]
        [RegularExpression("[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{3}")]
        public string CVC { get; set; }

        [Required]
        public CardType? Type { get; set; }
    }
}

//{
//    "FullName": "",
//    "Username": "invalid",
//    "Email": "invalid@invalid.com",
//    "Age": 20,
//    "Cards": [
//      {
//        "Number": "1111 1111 1111 1111",
//        "CVC": "111",
//        "Type": "Debit"
//      }
//    ]
//  },
