using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DataTransferObject.Output
{
    [XmlType("suplier")]
    public class SuppliersOutputModel
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("parts-count")]
        public int CountParts { get; set; }
    }
}

//< suppliers >
//  < suplier id = "2" name = "VF Corporation" parts - count = "3" />
