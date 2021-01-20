using System;

namespace PasswordGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            string pasword = Console.ReadLine();
            if (pasword != "s3cr3t!P@ssw0rd")
            {
                Console.WriteLine("Wrong password!");
            }
            else if (pasword == "s3cr3t!P@ssw0rd")
            {
                Console.WriteLine("Welcome");
            }
           
        }
    }
}
