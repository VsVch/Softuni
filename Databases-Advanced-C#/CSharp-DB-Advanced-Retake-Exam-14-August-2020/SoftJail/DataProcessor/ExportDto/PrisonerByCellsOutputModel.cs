using System;
using System.Collections.Generic;
using System.Text;

namespace SoftJail.DataProcessor.ExportDto
{
    public class PrisonerByCellsOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? CellNumber { get; set; }

        public ICollection<OfficersOutputModel> Officers { get; set; }

        public decimal TotalOfficerSalary { get; set; }
    }

    public class OfficersOutputModel 
    {
        public string OfficerName { get; set; }

        public string Department { get; set; }      
    }
}

//[
//  {
//    "Id": 3,
//    "Name": "Binni Cornhill",
//    "CellNumber": 503,
//    "Officers": [
//      {
//        "OfficerName": "Hailee Kennon",
//        "Department": "ArtificialIntelligence"
//      },
//      {
//    "OfficerName": "Theo Carde",
//        "Department": "Blockchain"
//      }
//    ],
//    "TotalOfficerSalary": 7127.93
//  },



//For each prisoner, get their id, name, cell number they are placed in, their officers with each officer name,
//and the department name they are responsible for.
//At the end export the total officer salary with exactly two digits after the decimal place.