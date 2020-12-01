using System;
using System.Linq.Expressions;

namespace _03.EasterTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            string contry = Console.ReadLine();
            string period = Console.ReadLine();
            int numberOfDays = int.Parse(Console.ReadLine());
            double price = 0;
            switch (contry)//"France", "Italy" или "Germany" "21-23", "24-27" или "28-31"
            {
                case "France":
                    if (period == "21-23")
                    {
                        price = numberOfDays * 30;
                    }
                    else if (period == "24-27")
                    {
                        price = numberOfDays * 35;
                    }
                    else if (period == "28-31")
                    {
                        price = numberOfDays * 40;
                    }
                    break;
                case "Italy":
                    if (period == "21-23")
                    {
                        price = numberOfDays * 28;
                    }
                    else if (period == "24-27")
                    {
                        price = numberOfDays * 32;
                    }
                    else if (period == "28-31")
                    {
                        price = numberOfDays * 39;
                    }
                    break;

                case "Germany":
                    if (period == "21-23")
                    {
                        price = numberOfDays * 32;
                    }
                    else if (period == "24-27")
                    {
                        price = numberOfDays * 37;
                    }
                    else if (period == "28-31")
                    {
                        price = numberOfDays * 43;
                    }
                    break;

            }
            Console.WriteLine($"Easter trip to {contry} : {price:f2} leva.");
        }
    }
}
