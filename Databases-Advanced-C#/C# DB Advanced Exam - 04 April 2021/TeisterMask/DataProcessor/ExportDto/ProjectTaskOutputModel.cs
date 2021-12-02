using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ProjectTaskOutputModel
    {
        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }

        [XmlElement("ProjectName")]
        public string Name { get; set; }

        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlArray("Tasks")]
        public TaskOutputModel[] Tasks { get; set; }
    }
    

    [XmlType("Task")]
    public class TaskOutputModel
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Label")]
        public string Label { get; set; }
    }
}

//< Project TasksCount = "10" > 
//     < ProjectName > Hyster - Yale </ ProjectName > 
//     < HasEndDate > No </ HasEndDate > 
//     < Tasks > 
//       < Task > 
//         < Name > Broadleaf </ Name > 
//         < Label > JavaAdvanced </ Label > 
//       </ Task > 
//       < Task > 
//         < Name > Bryum </ Name > 
//         < Label > EntityFramework </ Label > 
//       </ Task > 
//       < Task > 
//         < Name > Cornflag </ Name > 
//         < Label > CSharpAdvanced </ Label > 
//       </ Task >        
//         < Name > Longbract Pohlia Moss</Name>
//         <Label>EntityFramework</Label>
//       </Task>
//      <Task>
//        <Name>Meyen's Sedge</Name>
//        <Label>EntityFramework</Label>
//          </Task>
//      <Task>
//        <Name>Pacific</Name>
//            <Label>Priority</Label>
//          </Task>
//    </Tasks>
//  </Project>
