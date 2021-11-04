using Microsoft.Data.SqlClient;
using System;

namespace DBConections
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Integrated Security=true;Database=SoftUni";

            var conection = new SqlConnection(connectionString);
            conection.Open();

            conection.Close();
        }
    }
}
