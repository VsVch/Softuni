using EfCoreDemo.Models;
using System;

namespace EfCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var department = new Department { Name = "IT" };

            //var address = new Address { Descreption = "Nadejda -2 " };

            for (int i = 0; i < 10; i++)
            {
                db.Emploeeys.Add(new Employee
                {
                    EGN = "12345"+ i,
                    FirstName = "Sasho_" + i,
                    LastName = "Stefanov",
                    StartWorkDate = new DateTime(2010 + i, 1, 1),
                    Salary = 2500 + i,
                    Department = department,
                    Address = new Address { Descreption = $"Nadejda - {i}"},
                });
            }
           

            db.SaveChanges();
        }
    }
}
