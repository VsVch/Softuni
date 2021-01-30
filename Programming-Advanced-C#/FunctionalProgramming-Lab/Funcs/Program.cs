using System;

namespace Funcs
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int,DateTime, string> agePrinter = null;

           // Func<int, DateTime, string> agePrinterLambda =

               // (age, date) => $"{age}{date}";

            Console.WriteLine("Age now or then?");
            string input = Console.ReadLine();

            if (input == "now")
            {
                agePrinter = GetAge;

            }
            else if (input == "then") 
            {
                agePrinter = GetAgeIn10Yars;
            
            }

            Console.WriteLine(agePrinter(5, DateTime.Now));
           // Console.WriteLine(GetAge(5));
        }

        static string GetAge(int age, DateTime date)
        {
            return $"Your age is: {age} at {date}";
        }
        static string GetAgeIn10Yars(int age, DateTime date)
        {
            return $"Your age is: {age + 10} at {date}";
        }
    }
    
}
