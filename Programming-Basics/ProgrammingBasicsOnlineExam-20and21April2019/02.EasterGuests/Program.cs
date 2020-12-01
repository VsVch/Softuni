using System;

namespace _02.EasterGuests
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberGuests = int.Parse(Console.ReadLine());
            double buget = double.Parse(Console.ReadLine());
            double numberEasterCakes = Math.Ceiling(1.0 * numberGuests / 3);
            double numberEags = 1.0 * numberGuests * 2;
            double priceOfEasterCakes = numberEasterCakes * 4;
            double priceOfEags = numberEags * 0.45;
            double totallPrice = priceOfEags + priceOfEasterCakes;
            double money = Math.Abs(buget - totallPrice);
            if (buget >= totallPrice)
            {
                Console.WriteLine($"Lyubo bought {numberEasterCakes:f0} Easter bread and {numberEags:f0} eggs.");
                Console.WriteLine($"He has {money:f2} lv. left.");
            }
            else if (buget < totallPrice)
            {
                Console.WriteLine($"Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {money:f2} lv. more.");
            }
        }
    }
}
