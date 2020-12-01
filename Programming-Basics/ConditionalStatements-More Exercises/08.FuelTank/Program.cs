using System;

namespace _08.FuelTank
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuel = Console.ReadLine();
            double litersFuel = double.Parse(Console.ReadLine());
            // "Diesel", "Gasoline" или "Gas"
            switch (fuel)
            {
                case "Diesel":
                    if (litersFuel >= 25)
                    {
                        Console.WriteLine($"You have enough diesel.");
                    }
                    else if (litersFuel < 25)
                    {
                        Console.WriteLine($"Fill your tank with diesel!");
                    }
                    break;
                case "Gasoline":
                    if (litersFuel >= 25)
                    {
                        Console.WriteLine($"You have enough gasoline.");
                    }
                    else if (litersFuel < 25)
                    {
                        Console.WriteLine($"Fill your tank with gasoline!");
                    }
                    break;                    
                case "Gas":
                    if (litersFuel >= 25)
                    {
                        Console.WriteLine($"You have enough gas.");
                    }
                    else if (litersFuel < 25)
                    {
                        Console.WriteLine($"Fill your tank with gas!");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid fuel!");
                    break;
            }
        }
    }
}
