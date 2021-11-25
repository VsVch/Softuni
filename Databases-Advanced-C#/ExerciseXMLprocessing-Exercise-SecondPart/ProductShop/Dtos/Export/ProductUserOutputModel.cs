using System.Xml.Serialization;

[XmlType("Product")]
public class ProductUserOutputModel
{
    [XmlElement("name")]
    public string Name { get; set; }

    [XmlElement("price")]
    public decimal Price { get; set; }
}


//< User >
//    < firstName > Almire </ firstName >
//    < lastName > Ainslee </ lastName >
//    < soldProducts >
//      < Product >
//        < name > olio activ mouthwash</name>
//           <price>206.06</price>
//      </Product>
//      <Product>
//        <name>Acnezzol Base</name>
//        <price>710.6</price>
//      </Product>
//      <Product>
//        <name>ENALAPRIL MALEATE</name>
//        <price>210.42</price>
//      </Product>
//    </soldProducts>
//  </User>...

