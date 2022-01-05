using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class PlayerInportModel
    {
        [XmlElement("Title")]
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Title { get; set; }

        [Required]
        [XmlElement("Duration")]
        //[Range(typeof(TimeSpan), "01:00:00", "10675199.02:48:05.4775807")]
        public string Duration { get; set; }

        [Range(0.00, 10.00)]
        [XmlElement("Rating")]
        public float Rating { get; set; }

        [Required]
        [XmlElement("Genre")]
        public string Genre { get; set; }

        [Required]
        [XmlElement("Description")]
        [StringLength(700, MinimumLength = 0)]
        public string Description { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        [XmlElement("Screenwriter")]
        public string Screenwriter { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	Title – text with length [4, 50] (required)
//•	Duration – TimeSpan in format
//{ hours: minutes: seconds}, with a minimum length of 1 hour. (required)
//•	Rating – float in the range[0.00….10.00] (required)
//•	Genre – enumeration of type Genre, with possible values (Drama, Comedy, Romance, Musical) (required)
//•	Description – text with length up to 700 characters (required)
//•	Screenwriter – text with length [4, 30] (required)
//•	Casts - a collection of type Cast
//•	Tickets - a collection of type Ticket



//< Play >
//       < Title > The Hsdfoming </ Title >   
//       < Duration > 03:40:00 </ Duration >      
//       < Rating > 8.2 </ Rating >      
//       < Genre > Action </ Genre >      
//       < Description > A guyat Pinter turns into a debatable conundrum as oth ordinary and menacing. Much of this has to do with the fabled "Pinter Pause," which simply mirrors the way we often respond to each other in conversation, tossing in remainders of thoughts on one subject well after having moved on to another.</Description>
//    <Screenwriter>Roger Nciotti</Screenwriter>
//</Play>