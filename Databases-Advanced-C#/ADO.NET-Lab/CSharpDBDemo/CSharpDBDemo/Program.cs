using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CSharpDBDemo
{
    class Program
    {
        static void Main()
        {
            string connectionString = "Server=localhost; User Id=sa;Password=@Stefanov820605; Database=SoftUni";

            using (var conection = new SqlConnection(connectionString))
            {
                conection.Open();

                SqlCommand sqlCommand = new SqlCommand("UPDATE Employees SET Salary = Salary * 0.12 WHERE FirstName LIKE 'A%'", conection);
                var result = sqlCommand.ExecuteNonQuery();
                Console.WriteLine(result);

                var query = "SELECT COUNT(*) FROM Employees WHERE FirstName LIKE 'A%'";
                SqlCommand sqlCommand2 = new SqlCommand(query, conection);
                var result2 = sqlCommand2.ExecuteScalar();
                Console.WriteLine(result2);


                SqlCommand sqlCommand3 = new SqlCommand(@"SELECT FirstName, LastName, Salary, DepartmentID FROM Employees", conection);

                List<Employee> employees = new List<Employee>();

                using (SqlDataReader sqlDataReader = sqlCommand3.ExecuteReader())                   

                while (sqlDataReader.Read())
                {
                    //var data = (string)sqlDataReader["Name"]; //  var data = sqlDataReader["Name"] as string

                        Employee employee = new Employee
                        {
                            FirstName = (string)sqlDataReader["FirstName"],
                            LastName = (string)sqlDataReader["LastName"],
                            Salary = (decimal)sqlDataReader["Salary"],
                            DepartmentID = (int)sqlDataReader["DepartmentID"],

                        };

                        employees.Add(employee);

                   // Console.WriteLine($"{sqlDataReader["Name"]} => {sqlDataReader["Count"]}");
                }

                foreach (var item in employees.OrderBy(x => x.FirstName))
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName} -> {item.DepartmentID}: {item.Salary}$");
                }
            }
        }
    }

    public class Employee 
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public int DepartmentID { get; set; }
    }
}
