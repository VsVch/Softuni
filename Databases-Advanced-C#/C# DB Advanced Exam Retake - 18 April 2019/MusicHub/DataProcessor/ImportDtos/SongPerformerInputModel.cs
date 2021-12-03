using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Performer")]
    public class SongPerformerInputModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [XmlElement("LastName")]
        public string LastName { get; set; }

        [Range(18, 70)]
        [XmlElement("Age")]
        public int Age { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        [XmlElement("NetWorth")]
        public decimal NetWorth { get; set; }

        [XmlArray("PerformersSongs")]
        public SongDtoModel[] PerformersSongs { get; set; }
    }

    //•	Id – integer, Primary Key
    //•	FirstName– text with min length 3 and max length 20 (required) 
    //•	LastName– text with min length 3 and max length 20 (required) 
    //•	Age – integer(in range between 18 and 70)(required)
    //•	NetWorth – decimal(non - negative, minimum value: 0)(required)
    //•	PerformerSongs - collection of type SongPerformer


    [XmlType("Song")]
    public class SongDtoModel
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
    }
}
  //<Performer >
  //  < FirstName > Peter </ FirstName >
  //  < LastName > Bree </ LastName >
  //  < Age > 25 </ Age >
  //  < NetWorth > 3243 </ NetWorth >
  //  < PerformersSongs >
  //    < Song id = "2" /> 
  //     < Song id = "1" />  
  //  </ PerformersSongs >  
  //</Performer >
