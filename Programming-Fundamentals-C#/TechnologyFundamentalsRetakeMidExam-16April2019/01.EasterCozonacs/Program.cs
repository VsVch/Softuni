using System;

namespace _01.EasterCozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            double buget = double.Parse(Console.ReadLine());

            double priceForKgFlour = double.Parse(Console.ReadLine());

            double priceForOnePackEggs = priceForKgFlour * 0.75;

            double priceOneLiterMilk = priceForKgFlour * 1.25;

            double receptForOneCozonac = (priceOneLiterMilk / 4) + priceForKgFlour + priceForOnePackEggs;

            int coloredEggs = 0;

            int currentCozonacCount = 0;

            while (buget > receptForOneCozonac)
            {
                buget -= receptForOneCozonac;
                currentCozonacCount++;
                coloredEggs += 3;

                if (currentCozonacCount % 3 == 0)
                {
                    coloredEggs -= currentCozonacCount - 2;
                }

            }
            Console.WriteLine($"You made {currentCozonacCount} cozonacs! Now you have {coloredEggs} eggs and {buget:f2}BGN left.");
        }
    }
}
