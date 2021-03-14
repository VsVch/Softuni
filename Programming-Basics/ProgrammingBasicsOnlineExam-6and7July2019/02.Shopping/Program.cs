using System;

namespace _02.Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double buget = double.Parse(Console.ReadLine());
            int numberVideoCards = int.Parse(Console.ReadLine());
            int numberProcessors = int.Parse(Console.ReadLine());
            int numberRamMemorys = int.Parse(Console.ReadLine());
            double priceOfVideoCards = 1.0 * numberVideoCards * 250;
            double priceOfProcesors = 1.0 * priceOfVideoCards * 0.35 * numberProcessors;
            double priceOfRamMemorys = 1.0 * priceOfVideoCards * 0.10 * numberRamMemorys;
            double price = priceOfVideoCards + priceOfProcesors + priceOfRamMemorys;
            if (numberVideoCards > numberProcessors)
            {
                price *= 0.85;
            }
            double money = Math.Abs(buget - price);
            if (buget >= price)
            {
                Console.WriteLine($"You have {money:f2} leva left!");
            }
            else if (buget < price)
            {
                Console.WriteLine($"Not enough money! You need {money:f2} leva more!");
            }
        }
    }
}
