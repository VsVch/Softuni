namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
       
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {

            var projects = context.Projects
                .Where(x => x.Tasks.Any())
                .ToArray()
                .Select(x => new ProjectTaskOutputModel
                {
                    TasksCount = x.Tasks.Count(),
                    Name = x.Name,
                    HasEndDate = string.IsNullOrWhiteSpace((x.DueDate).ToString()) ? "No" : "Yes",
                    Tasks = x.Tasks.Select(t => new TaskOutputModel
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .OrderByDescending(x => x.TasksCount)
                .ThenBy(x => x.Name)               
                .ToArray();


            var sb = new StringBuilder();          
            var stringWriter = new StringWriter(sb);            

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProjectTaskOutputModel[]),
                new XmlRootAttribute("Projects"));

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(stringWriter, projects, ns);                 
                 

            return stringWriter.ToString();
        }
                

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {

            var employees = context.Employees                
                .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .ToList()
                .Select(x => new
                 {
                     Username = x.Username,
                     Tasks = x.EmployeesTasks
                    .Where(et => et.Task.OpenDate >= date)
                    .ToList()
                    .OrderByDescending(t => t.Task.DueDate)
                    .ThenBy(t => t.Task.Name)
                    .Select(et => et.Task)
                    .Select(t => new
                    {
                        TaskName = t.Name,
                        OpenDate = t.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = t.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = t.LabelType.ToString(),
                        ExecutionType = t.ExecutionType.ToString()
                    })                    
                    .ToList()
                 })
                .OrderByDescending(x => x.Tasks.Count())
                .ThenBy(x => x.Username)
                .Take(10)
                .ToList();

            var result = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return result;
        }
    }
}