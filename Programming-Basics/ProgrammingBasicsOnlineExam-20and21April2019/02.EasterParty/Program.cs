using System;

namespace _02.EasterParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGests = int.Parse(Console.ReadLine());
            double priceForPlate = double.Parse(Console.ReadLine());
            double buget = double.Parse(Console.ReadLine());
            double priceOfAllGuests = numberOfGests * priceForPlate;
            if (numberOfGests >= 10 && numberOfGests <= 15)
            {
                priceOfAllGuests *= 0.85;
            }
            else if (numberOfGests > 15 && numberOfGests <= 20)
            {
                priceOfAllGuests *= 0.80;
            }
            else if (numberOfGests > 20)
            {
                priceOfAllGuests *= 0.75;
            }
            double priceForCake = buget * 0.1;
            double newBuget = buget - priceForCake;
            double sum = Math.Abs(newBuget - priceOfAllGuests);
            if (newBuget >= priceOfAllGuests)
            {
                Console.WriteLine($"It is party time! {sum:f2} leva left.");
            }
            if (newBuget < priceOfAllGuests)
            {
                Console.WriteLine($"No party! {sum:f2} leva needed.");
            }
        }
    }
}
