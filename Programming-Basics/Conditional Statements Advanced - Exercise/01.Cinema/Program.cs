using System;

namespace _01.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string tipeProgection = Console.ReadLine();
            double rRow = double.Parse(Console.ReadLine());
            double cColumn = double.Parse(Console.ReadLine());
            double fullArena = rRow * cColumn;
            double price = 0;
            switch (tipeProgection)

            {
                case "Premiere":
                    price = 12.0;
                    break;
                case "Normal":
                    price = 7.50;
                    break;
                case "Discount":
                    price = 5.0;
                    break;

            }
            double income = fullArena * price;
            Console.WriteLine($"{income:f2} leva,");
        }
    }
}
