using System;

namespace _01.TennisEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double tennisRacketPrice = double.Parse(Console.ReadLine());
            int numberOfTennisRackets = int.Parse(Console.ReadLine());
            int numberOfTennisShoues = int.Parse(Console.ReadLine());
            double priceOftennisRackets = numberOfTennisRackets * tennisRacketPrice;
            double priceOfThennisShoues = numberOfTennisShoues * tennisRacketPrice / 6;
            double totalPriceForShouesAndRackets = priceOftennisRackets + priceOfThennisShoues;
            double otherEqupment = totalPriceForShouesAndRackets * 0.2;
            double totalPrice = otherEqupment + priceOfThennisShoues + priceOftennisRackets;
            double pricePayedFromJocovich = Math.Floor(totalPrice / 8);
            double praysPayedFromSponsors = totalPrice - pricePayedFromJocovich;
            Console.WriteLine($"Price to be paid by Djokovic {pricePayedFromJocovich:f0}");
            Console.WriteLine($"Price to be paid by sponsors {praysPayedFromSponsors:f0}");
        }
    }
}
