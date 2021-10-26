using DBFirstModel.Models;
using System;
using System.Linq;

namespace DBFirstModel
{
    //Microsoft.EntityFrameworkCore.SqlServer
    //Microsoft.EntityFrameworkCore.Design
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();

            //AddColectionFromDB(db);
            //AddObjectInDB(db);         
            //JoinFromDb(db);       
        }

        private static void JoinFromDb(SoftUniContext db)
        {
            var departments = db.Employees.GroupBy(x => x.Department.Name)
                .Select(x => new { Name = x.Key, Count = x.Count() })
                .ToList();

            foreach (var item in departments)
            {
                Console.WriteLine($"{item.Name} => {item.Count}");
            }
        }

        private static void AddObjectInDB(SoftUniContext db)
        {
            db.Towns.Add(new Town { Name = "Pernik" });
            db.SaveChanges();
        }

        private static void AddColectionFromDB(SoftUniContext db)
        {
            var emploees = db.Employees.ToList();

            foreach (var item in emploees.Where(x => x.FirstName.StartsWith('A')).OrderByDescending(x => x.Salary).ThenBy(x => x.LastName))
            {
                Console.WriteLine(item.FirstName + ' ' + item.LastName + ' ' + item.Salary);
            }
        }
    }
}
