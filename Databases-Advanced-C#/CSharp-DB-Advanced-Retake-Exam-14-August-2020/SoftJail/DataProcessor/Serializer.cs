namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Serialization;

    public class Serializer
    {
        
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners.Where(x => ids.Contains(x.Id))
                .Select(x => new PrisonerByCellsOutputModel
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(o => new OfficersOutputModel
                    {
                        OfficerName = o.Officer.FullName,
                        Department = o.Officer.Department.Name
                       
                    })
                    .OrderBy(o => o.OfficerName)
                    .ToList(),
                     TotalOfficerSalary = decimal.Parse(x.PrisonerOfficers.Sum(off => off.Officer.Salary).ToString("f2"))
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToList();

               var result = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return result;
                 
        }

       // Use the method provided in the project skeleton, which receives a string of comma-separated prisoner names.
       // Export the prisoners: for each prisoner, export its id, name,
       // incarcerationDate in the format “yyyy-MM-dd” and their encrypted mails.
       // The encrypted algorithm you have to use is just to take each prisoner mail description and reverse it.
       // Sort the prisoners by their name (ascending), then by their id (ascending).

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            const string root = "Prisoners";

            var prisonersName = new List<string>();

            prisonersName = prisonersNames
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var prisoners = context.Prisoners
                .Where(x => prisonersName.Contains(x.FullName))
                .Select(x => new PrisonerInboxOutputModel
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = x.Mails.Select(m => new MailOutputMassege
                    {
                        Description = string.Join("", m.Description.Reverse())
                    })
                    .ToArray()

                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToList();

            var result = XmlConverter.Serialize(prisoners, root);

            return result;
        }
    }
}