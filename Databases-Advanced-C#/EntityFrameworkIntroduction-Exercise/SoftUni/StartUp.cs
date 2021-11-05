using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
             SoftUniContext context = new SoftUniContext();

             var result = GetLatestProjects(context);

             Console.WriteLine(result);
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                .Include(x => x.Addresses)
                .FirstOrDefault(x => x.Name == "Seattle");

            var alladdressIds = town.Addresses.Select(x => x.AddressId).ToList();

            var employeesId = context.Employees
                .Where(x =>x.AddressId.HasValue && alladdressIds.Contains(x.AddressId.Value))
                .ToList();

            foreach (var employee in employeesId)
            {
                employee.AddressId = null;
            }           

            foreach (var addressId in alladdressIds)
            {
                var address = context.Addresses.FirstOrDefault(x => x.AddressId == addressId);
                context.Addresses.Remove(address);
            }

            context.Towns.Remove(town);
            context.SaveChanges();

            return $"{alladdressIds.Count} addresses in Seattle were deleted";
        }

        public static string DeleteProjectById(SoftUniContext context) 
        {
            
            var project = context.Projects.Find(2);         

            var allEmployesOnProject = context.EmployeesProjects.Where(x => x.ProjectId == 2).ToList();

            foreach (var employee in allEmployesOnProject)
            {
                employee.Project = null;             
            }
            context.SaveChanges();

            context.Remove(project);
            context.SaveChanges();

            var tenProjects = context.Projects.Take(10).ToList();

            var sb = new StringBuilder();

            foreach (var item in tenProjects)
            {
                sb.AppendLine(item.Name);
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employeeWhitSa = context.Employees.Where(x => x.FirstName.StartsWith("Sa") ||
                                                         x.FirstName.StartsWith("sa") ||
                                                         x.FirstName.StartsWith("sA"))
                //Where(x => x.FirstName.StartsWith("Sa", true, CultureInfo.InvariantCulture) -> different approach for where clause
                //Where(x => EF.Functions.Like(x.FirstName, "sa%")) -> another approach;
                .ToList();

            var sb = new StringBuilder();

            foreach (var item in employeeWhitSa.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} - {item.JobTitle} - (${item.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }


        public static string IncreaseSalaries(SoftUniContext context)
        {
            var department = new string[]
            { "Engineering", "Tool Design", "Marketing","Information Services" };
            var salaryIncrease = context.Employees                
                .Where(x => department.Contains(x.Department.Name))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)                
                .ToList();

            foreach (var item in salaryIncrease)
            {
                item.Salary *= 1.12m;
            }

            context.SaveChanges();

            var sb = new StringBuilder();

            foreach (var item in salaryIncrease)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} (${item.Salary:f2})");
            }               

            return sb.ToString().TrimEnd();
        }


        public static string GetLatestProjects(SoftUniContext context)
        {
            var latestProjects = context.Projects
                .OrderByDescending(x => x.StartDate.Year)
                .ThenByDescending(x => x.StartDate.Month)
                .ThenByDescending(x => x.StartDate.Day)
                .ThenByDescending(x => x.StartDate.Hour)
                .ThenByDescending(x => x.StartDate.Minute)
                .ThenByDescending(x => x.StartDate.Second)
                .Select(x => new 
                {
                    x.Name,
                    x.Description,
                    x.StartDate
                })
                .Take(10)
                .ToList();           

            var sb = new StringBuilder();

            foreach (var item in latestProjects.OrderBy(x => x.Name))
            {
                sb.AppendLine($"{item.Name}");
                sb.AppendLine($"{item.Description}");
                sb.AppendLine($"{item.StartDate.ToString("M/d/yyyy h:mm:ss tt").TrimEnd()}");                
            }
           
            return sb.ToString().TrimEnd();
        }


        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
                       
            var seleectedDepartments = context.Departments
                .Where(x => x.Employees.Count() > 5)
                .OrderBy(x => x.Employees.Count())
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    x.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Employee = x.Employees.Select(e => new
                    {
                        EmployeeFirstName = e.FirstName,
                        EmployeeLastName = e.LastName,
                        EmployeeJobName = e.JobTitle
                    })
                   .OrderBy(x => x.EmployeeFirstName)
                   .ThenBy(x => x.EmployeeLastName)
                   .ToList()
                })                
                .ToList();

            var sb = new StringBuilder();

            foreach (var department in seleectedDepartments)
            {
                sb.AppendLine($"{department.Name} – {department.ManagerFirstName} {department.ManagerLastName}");

                foreach (var item in department.Employee)
                {
                    sb.AppendLine($"{item.EmployeeFirstName} {item.EmployeeLastName} - {item.EmployeeJobName}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context.Employees
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    Project = x.EmployeesProjects.Select(p => new 
                    { 
                        p.Project.Name
                    })
                    .OrderBy(p => p.Name)
                    .ToList()
                })                
                .FirstOrDefault(x => x.EmployeeId == 147);

            var sb = new StringBuilder();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var item in employee147.Project)
            {
                sb.AppendLine($"{item.Name}");
            }                     

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {

            var addresses = context.Addresses.OrderByDescending(x => x.Employees.Count)
                                   .ThenBy(x => x.Town.Name)
                                   .ThenBy(x => x.AddressText)
                                   .Select(x => new 
                                   { 
                                      AddressText = x.AddressText,
                                      TownName = x.Town.Name,
                                      EmployeesCount = x.Employees.Count(),
                                   })
                                   .Take(10)
                                   .ToList();
            var sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                  .Include(x => x.EmployeesProjects)
                  .ThenInclude(x => x.Project)
                  .Where(x => x.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                  .Select(x => new
                  {
                      EmployeeFirstName = x.FirstName,
                      EmployeeLastName = x.LastName,
                      ManagerFirstName = x.Manager.FirstName,
                      ManagerLastName = x.Manager.LastName,
                      Projects = x.EmployeesProjects.Select(p => new
                      {
                          ProjectName = p.Project.Name,
                          StartDate = p.Project.StartDate,
                          EndDate = p.Project.EndDate,
                      })
                      .ToList()
                  })
                  .Take(10)
                  .ToList();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.EmployeeFirstName} {emp.EmployeeLastName} - Manager: {emp.ManagerFirstName} {emp.ManagerLastName}");

                foreach (var project in emp.Projects)
                {
                    var projectName = project.EndDate == null ? "not finished" : project.EndDate.ToString();

                    sb.AppendLine($"--{project.ProjectName} - {project.StartDate} - {projectName}");
                }
            }
                
            return sb.ToString().Trim();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context) 
        {
            var addres = new Address 
            { 
                AddressText = "Vitoshka 15",
                TownId = 4,
            };

            context.Addresses.Add(addres);
            context.SaveChanges();

            var currEmployee = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");

            currEmployee.AddressId = addres.AddressId;

            context.SaveChanges();

            var emploees = context.Employees
                .Select(x => new
                {
                    x.Address.AddressText,
                    x.AddressId,
                })
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var emp in emploees)
            {
                sb.AppendLine($"{emp.AddressText}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary,
                   DepartmentName = e.Department.Name,
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} from {emp.DepartmentName} - ${emp.Salary:f2}");
            }
                
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employess = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employess)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }


            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var emplayees = context.Employees                
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary,
                })
                .OrderBy(x => x.EmployeeId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var emplayee in emplayees)
            {
                sb.AppendLine($"{emplayee.FirstName} {emplayee.LastName} {emplayee.MiddleName} {emplayee.JobTitle} {emplayee.Salary:f2}");
            }

            var result = sb.ToString().Trim();

            return result;
        }        
    }
}
