using dbLINQDemo.Models;
using System;
using System.Linq;
using System.Text;

namespace dbLINQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            var db = new SoftUniContext();

            //FindEmployeesNameStartsWhitA(db);           
            //FindEmployeesWhitDepartment(db);
            //Updateprojects(db);
            //SomeAggregationFunction(db);
            //UsingJoinFunction(db);
            //UsingGroupBy(db);
            //UsingSelectMany(db);                       
        }

        private static void UsingSelectMany(SoftUniContext db)
        {
            var employees = db.Employees
                .SelectMany(x => x.EmployeesProjects
                .Select(x => new 
                { 
                  FullName =  x.Employee.FirstName + " " + x.Employee.LastName,                
                  ProjectName = x.Project.Name 
                }))
                .ToList();

            foreach (var employee in employees)
            {                
               Console.WriteLine(employee.FullName + " - " + employee.ProjectName);                
            }
        }

        private static void UsingGroupBy(SoftUniContext db)
        {
            var employees = db.Employees
               .GroupBy(x => x.LastName.Substring(0, 1))
               .Select(x => new
               {
                   Firstletter = x.Key,
                   Count = x.Count(),
                   Min = x.Min(x => x.LastName),
                   Max = x.Max(x => x.LastName)
               })
               .ToList();
            foreach (var item in employees)
            {
                Console.WriteLine(item.Firstletter + " " + item.Count + " - " + item.Min + " - "+ item.Max);
            }
        }

        private static void UsingJoinFunction(SoftUniContext db)
        {
            var employees = db.Employees
               .Join(db.Departments, x => x.DepartmentId, x => x.DepartmentId, (employee, department) => new
               {
                   DepartmentName = department.Name,
                   FullName = string.Join(" ", employee.FirstName, employee.LastName)

               })
               .ToList();

            foreach (var item in employees)
            {
                Console.WriteLine(item.FullName + " " + item.DepartmentName);
            }

        }

        private static void SomeAggregationFunction(SoftUniContext db)
        {
            var employees = db.Employees
                .Where(x => x.FirstName.StartsWith("N"))
                .Count();

            Console.WriteLine(employees);

            var employeesWithN = db.Employees
                .OrderBy(x => x.FirstName.Length)
                .ThenBy(x => x.FirstName)
                .Where(x => x.FirstName.Length > 5)
                .Select(x => new { x.FirstName, Count = x.FirstName.Count() })
                //.Where(x => x.FirstName.StartsWith("N"))
                .ToList();

            foreach (var emplyee in employeesWithN)
            {
                Console.WriteLine(emplyee.FirstName + ' ' + emplyee.Count);
            }

        }

        private static void Updateprojects(SoftUniContext db)
        {
            var projects = db.Projects
                .Where(x => x.EndDate == null)
                .ToList();

            // can't use select in request wehn update and delete database

            foreach (var project in projects)
            {
                project.EndDate = DateTime.UtcNow;
            }

            db.SaveChanges();
        }

        private static void FindEmployeesWhitDepartment(SoftUniContext db)
        {
            var employess = db.Employees
                .Where(x => x.Department.Name == "Engineering")
                .Select(x => new
                {
                   //x.FirstName,
                   //x.LastName,
                    FullName = string.Join(" ", x.FirstName, x.LastName),
                    x.Salary,
                    x.Department.Name
                })
                .ToList();

            foreach (var employee in employess)
            {
                //Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.Salary:f2} - {employee.Name}");
                Console.WriteLine($"{employee.FullName} {employee.Salary:f2} - {employee.Name}");
            }
        }

        private static void FindEmployeesNameStartsWhitA(SoftUniContext db)
        {
            var employes = db.Employees
               .Where(x => x.FirstName.StartsWith("A"))
               .ToList();

            Console.WriteLine(employes.Count());

            Console.WriteLine(db.Employees.Count(x => x.FirstName.StartsWith("A"))); // -> better approach            
        }
    }
}
