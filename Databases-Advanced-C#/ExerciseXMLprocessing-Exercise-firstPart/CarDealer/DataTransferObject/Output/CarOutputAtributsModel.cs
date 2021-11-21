using System.Xml.Serialization;

[XmlType("car")]
public class CarOutputAtributsModel 
{
    [XmlAttribute("make")]
    public string Make { get; set; }

    [XmlAttribute("model")]
    public string Model { get; set; }

    [XmlAttribute("travelled-distance")]
    public long TravelledDistance { get; set; }
}
  //< sale >
  //  < car make = "BMW" model = "M5 F10" travelled - distance = "435603343" />     
  //  < discount > 30.00 </ discount >     
  //  < customer - name > Hipolito Lamoreaux </ customer - name >          
  //  < price > 707.97 </ price >          
  //  < price - with - discount > 495.58 </ price - with - discount >          
  //</ sale >
