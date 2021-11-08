using AdvancedQuerying.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Z.EntityFramework.Plus;

namespace AdvancedQuerying
{
    class Program
    {
        public static int EntityFramework { get; private set; }

        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            

            //UpdateWhitSQLCode(db);
            //SelectWhitFromSqlRawCommand(db);
            //SQLTrackChanges(db);
            //SQLUsingAsNoTracking(db);
            //SQLAttachAndDetach(db);
            //EntityFrameworkPlusDeleteFunction(db);
            //LoadingDataFromSQL(db);
            //OptimisticConcurrency(db);

        }

        private static void OptimisticConcurrency(SoftUniContext db)
        {
            // attribute [ConcurrencyCheck] throw error
            var firstEmployeeDb = db.Employees
                .FirstOrDefault(x => x.EmployeeId == 1);

            var dbTwo = new SoftUniContext();
            var firstEmployeeDbTwo = dbTwo.Employees
                .FirstOrDefault(x => x.EmployeeId == 1);

            firstEmployeeDb.Salary += 1000;

            db.SaveChanges();
            while (true)
            {
                try
                {                  
                    firstEmployeeDbTwo.Salary += 1000;
                    dbTwo.SaveChanges();
                    break;

                }
                catch 
                {
                    dbTwo = new SoftUniContext();
                    firstEmployeeDbTwo = dbTwo.Employees
                        .FirstOrDefault(x => x.EmployeeId == 1);
                }
            }        
           
        }

        private static void LoadingDataFromSQL(SoftUniContext db)
        {

            var employees = db.Employees
                .Include(x => x.Department) // eager loading whit include
                .Include(x => x.EmployeesProjects).ThenInclude(x => x.Project)
                .Where(x => x.EmployeeId <= 10)
                //.Select(x => new { x.FirstName,  x.Department.Name}) // loading whit projection
                .ToArray();

            foreach (var emp in employees)
            {
                //Explicite loading
                //db.Entry(emp).Reference(x => x.Department).Load();
               
                

                //Lazy loading -> 3 staps:
                                //1 step - virtual propertys on collections, navigation property; 
                                //2 step - install Microsoft.EntityFrameworkCore.Proxies;
                                //3 step - on dbContext -> OnConfiguring -> optionsBuilder -> add UseLazyLoadingProxies() method.


                // code works but n + 1 problems
                Console.WriteLine(emp.FirstName);
                Console.WriteLine(emp.Department.Name);

                foreach (var project in emp.EmployeesProjects)
                {
                    Console.WriteLine(project.Project.Name);
                }

            }
        }

        private static void EntityFrameworkPlusDeleteFunction(SoftUniContext db)
        {
            // install Z.EntityFramework.Plus.EFCore

            var employess = db.EmployeesProjects
             .Where(x => x.ProjectId <= 10)
             .Delete();

        }

        private static void SQLAttachAndDetach(SoftUniContext db)
        {
            var employess = db.Employees
               .Where(x => x.FirstName.Contains("sa"));            

            foreach (var employee in employess)
            {
                // detach
                db.Entry(employee).State = EntityState.Detached;

                Console.WriteLine(employee.FirstName + " " + employee.LastName);

                // attach
                db.Entry(employee).State = EntityState.Modified;

                employee.Salary += 1000;
            }

            db.SaveChanges();
        }

        private static void SQLUsingAsNoTracking(SoftUniContext db)
        {
            var employess = db.Employees
               .AsNoTracking()
               .Where(x => x.FirstName.Contains("sa")); // => can be used for faster performens only wehn select information form db

            foreach (var employee in employess)
            {
                Console.WriteLine(employee.FirstName + " " + employee.LastName);                         
            }
        }

        private static void SQLTrackChanges(SoftUniContext db)
        {
            var employess = db.Employees
                .Where(x => x.FirstName.Contains("sa"));
              //.Select(x => new { x.FirstName, x.LastName}) => SQL change tracker can't track changes in anonymous object or projection.

            foreach (var employee in employess)
            {
                Console.WriteLine(employee.FirstName + " " + employee.LastName);

                employee.Salary += 1000;
            }

            db.SaveChanges();
        }

        private static void SelectWhitFromSqlRawCommand(SoftUniContext db)
        {
            var maxId = int.Parse(Console.ReadLine());

            var employees = db.Employees
             //($"SELECT * FROM Employees WHERE EmployeeID <= {maxId}"); => SQL Injection
             //.FromSqlRaw("SELECT * FROM Employees WHERE EmployeeID <= {0}", maxId); // => first way to protect from SQL injection
             .FromSqlInterpolated($"SELECT * FROM Employees WHERE EmployeeID <= {maxId}"); // => second way to protect 

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.FirstName + " " + employee.LastName);
            }
        }

        private static void UpdateWhitSQLCode(SoftUniContext db)
        {
          var song =  db.Database.ExecuteSqlRaw
                ("UPDATE Employees SET MiddleName = 'A' WHERE MiddleName is NULL");
        }
    }
}
