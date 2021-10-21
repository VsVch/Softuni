using Microsoft.Data.SqlClient;
using System;

namespace SQLInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plase enter username: ");
            var userName = Console.ReadLine();
            Console.WriteLine("Plase enter password: ");
            var pasword = Console.ReadLine();

            using (var connection = new SqlConnection
                ("Server=localhost; User Id=sa;Password=@Stefanov820605; Database=Service")) 
            {
                var wrongWay = $"SELECT COUNT(*) FROM Users WHERE Username = '{userName}' AND Password = '{pasword}'";
                var rightWay = $"SELECT COUNT(*) FROM Users WHERE Username = @UserName AND Password = @Password";
                connection.Open();
                var sqlCommand = new SqlCommand
                    (rightWay,  connection);

                sqlCommand.Parameters.Add(new SqlParameter("@UserName", userName));
                sqlCommand.Parameters.Add(new SqlParameter("@Password", pasword));

                var usersCount = (int)sqlCommand.ExecuteScalar();

                if (usersCount > 0)
                {
                    Console.WriteLine("Access granted!");
                }
                else
                {
                    Console.WriteLine("Access denied.");
                }
            }
        }
    }
}
