using AutoMappingObjects.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Text;
using AutoMappingObjects.MapperProfiles;

namespace AutoMappingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            var db = new SoftUniContext();

            var config = new MapperConfiguration(config =>
            {
                config.AddProfile(new EmployeeInfpDtoProfile());
                config.CreateMap<Employee, EmployeeName>(); ;
            });
            var mapper = config.CreateMapper();

            //Employee currEmployee = db.Employees
            //  .Where(e => e.EmployeeId == 4)
            //  .FirstOrDefault();

            //EmployeInfoDto employeInfoDto = mapper.Map<EmployeInfoDto>(currEmployee);
            //Console.WriteLine(JsonConvert.SerializeObject(employeInfoDto, Formatting.Indented));

            //EmployeeName employeName = mapper.Map<EmployeeName>(currEmployee);
            //Console.WriteLine(JsonConvert.SerializeObject(employeName, Formatting.Indented));

            //var result = GetEmployeeById(db, 1);
            //Console.WriteLine(JsonConvert.SerializeObject(result,Formatting.Indented));
            //Console.WriteLine(string.Join(Environment.NewLine, result.Select(x => $"{x.FullName} -> {x.Salary:f2}")));

            var employeeInfo = db.Employees
            .Where(e => e.FirstName.StartsWith("E"))
            .ProjectTo<EmployeInfoDto>(config)
            .ToList();

            Console.WriteLine(JsonConvert.SerializeObject(employeeInfo, Formatting.Indented));


            // reverce auto mapping => can create new Employee and add on the database :)

            //EmployeInfoDto firstEmployee = employeeInfo.FirstOrDefault();
            //Employee employee = mapper.Map<Employee>(firstEmployee);

            //db.Employees.Add(employee);
            //db.SaveChanges();            
        }

        static EmployeInfoDto GetEmployeeById(SoftUniContext db, int id)
        {
            var currEmployee = db.Employees
                .Where(e => e.EmployeeId == id)
                .FirstOrDefault();

            var employeDto = new EmployeInfoDto
            {
                FullName = currEmployee.FirstName + " " + currEmployee.LastName,
                Salary = currEmployee.Salary,
                HireDate = currEmployee.HireDate,
                JobTitle = currEmployee.JobTitle
            };

            return employeDto;
        }

        // Service method
        static IEnumerable<EmployeInfoDto> GetEmployeee(SoftUniContext db, string chatInput) 
        {
            var employes = db.Employees
                .Where(e => e.FirstName.StartsWith("A"))
                .Select(x => new EmployeInfoDto
                {
                    FullName = string.Join(" ",x.FirstName, x.LastName),
                    Salary = x.Salary,
                    HireDate = x.HireDate,
                    JobTitle = x.JobTitle
                })
                .ToList();

            return employes;
        }
    }

    class EmployeInfoDto
    {
        public string FullName { get; set; }

        public decimal Salary { get; set; }

        public DateTime HireDate { get; set; }

        public string JobTitle { get; set; }

        public string DepartmentName { get; set; } // another table info

        public string AddressAddressText { get; set; } // another table info

        public int EmployeesProjectsCount { get; set; } // => collection count

        public string ProjectsName { get; set; }
    }

    class EmployeeName 
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
