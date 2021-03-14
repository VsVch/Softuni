using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;

namespace _07.TheatrePromotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string taypOfDay = Console.ReadLine();
            int ageOfPersone = int.Parse(Console.ReadLine());
            double price = 0;
            if (ageOfPersone >= 0 && ageOfPersone <= 18)    
            {
                switch (taypOfDay)  
                {
                    case "Weekday":
                        price = 12;
                        break;
                    case "Weekend":
                        price = 15;
                        break;
                    case "Holiday":
                        price = 5;
                        break;                    
                }
            }
            else if (ageOfPersone > 18 && ageOfPersone <= 64)
            {
                switch (taypOfDay)
                {
                    case "Weekday":
                        price = 18;
                        break;
                    case "Weekend":
                        price = 20;
                        break;
                    case "Holiday":
                        price = 12;
                        break;
                }
            }
            else if (ageOfPersone > 64 && ageOfPersone <= 122)
            {
                switch (taypOfDay)
                {
                    case "Weekday":
                        price = 12;
                        break;
                    case "Weekend":
                        price = 15;
                        break;
                    case "Holiday":
                        price = 10;
                        break;
                }
            }
            else if (ageOfPersone < 0 || ageOfPersone > 122)
            {
                Console.WriteLine($"Error!");
                Environment.Exit(0);                
            }
            Console.WriteLine($"{price}$");
        }
    }
}
