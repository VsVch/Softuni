namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var result = new List<Department>();

            var departmentsDto = JsonConvert.DeserializeObject<IEnumerable<DepartmentCellInputModel>>(jsonString);

            foreach (var departmentDto in departmentsDto)
            {
                if (!IsValid(departmentDto) ||
                    !departmentDto.Cells.All(IsValid) ||
                    !departmentDto.Cells.Any())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var department = new Department
                {
                    Name = departmentDto.Name,
                    Cells = departmentDto.Cells.Select(s => new Cell
                    {
                        CellNumber = s.CellNumber,
                        HasWindow = s.HasWindow
                    })
                    .ToList()
                };             

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
                result.Add(department);
            }

            context.Departments.AddRange(result);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersMailsDto = JsonConvert.DeserializeObject<IEnumerable<PrisonerMailInputModel>>(jsonString);

            var sb = new StringBuilder();
            var result = new List<Prisoner>();

            foreach (var prisonerMail in prisonersMailsDto)
            {
                if (!IsValid(prisonerMail) ||                    
                    !prisonerMail.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var isValidReleseDate = DateTime.TryParseExact
                    (prisonerMail.ReleaseDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime releaseDate);

                var incarcerationDate = DateTime.ParseExact
                    (prisonerMail.IncarcerationDate,
                    "dd/MM/yyyy", 
                    CultureInfo.InvariantCulture);


                var prisoner = new Prisoner
                {
                    FullName = prisonerMail.FullName,
                    Nickname = prisonerMail.Nickname,
                    Age = prisonerMail.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = isValidReleseDate ? (DateTime?)releaseDate : null,                    
                    Bail = prisonerMail.Bail,
                    CellId = prisonerMail.CellId,                    
                    Mails = prisonerMail.Mails.Select(x => new Mail
                    {
                        Description = x.Description,
                        Sender = x.Sender,
                        Address = x.Address
                    })
                    .ToList()
                };          
                       
                result.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(result);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            const string root = "Officers";

            var sb = new StringBuilder();
            var result = new List<Officer>();

            var officersDto = XmlConverter.Deserializer
                <OfficerPrisonerInputModel>(xmlString, root);

            foreach (var officerDto in officersDto)
            {
                if (!IsValid(officerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var officer = new Officer 
                {
                    FullName =officerDto.Name,
                    Salary = officerDto.Salary,
                    Position = Enum.Parse<Position>(officerDto.Position),
                    Weapon = Enum.Parse<Weapon>(officerDto.Weapon),
                    DepartmentId = officerDto.DepartmentId,
                    OfficerPrisoners =officerDto.Prisoners.Select(x => new OfficerPrisoner 
                    { 
                        PrisonerId = x.PrisonerId,
                        
                    })
                    .ToArray()
                };

                result.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(result);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}