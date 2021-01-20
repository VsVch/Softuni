using System;

namespace _04.FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            const int priceSpring = 3000;
            const int priceSummerAutumn = 4200;
            const int priceWinter = 2600;
            double buget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numbersFisherman = int.Parse(Console.ReadLine());
            double price = 0;
            switch (season)
            {
                case "Spring":
                    price = priceSpring;
                    if (numbersFisherman <= 6)
                    {
                        price *= 0.9;                        
                    }
                    else if (numbersFisherman > 7 && numbersFisherman <= 11)
                    {
                        price *= 0.85;
                    }
                    else if (numbersFisherman > 12)
                    {
                        price *= 0.75;
                    }
                    break;
                case "Summer":
                case "Autumn":
                    price = priceSummerAutumn;
                    if (numbersFisherman <= 6)
                    {
                        price *= 0.9;
                    }
                    else if (numbersFisherman > 7 && numbersFisherman <= 11)
                    {
                        price *= 0.85;
                    }
                    else if (numbersFisherman > 12)
                    {
                        price *= 0.75;
                    }
                    break;
                case "Winter":
                    price = priceWinter;
                    if (numbersFisherman <= 6)
                    {
                        price *= 0.9;
                    }
                    else if (numbersFisherman > 7 && numbersFisherman <= 11)
                    {
                        price *= 0.85;
                    }
                    else if (numbersFisherman > 12)
                    {
                        price *= 0.75;
                    }
                    break;
                
            }
            if (numbersFisherman % 2 == 0 && season != "Autumn")
            {
                price *= 0.95;
            }
            if (buget > price)
            {
                double totalMoneyLeft = buget - price;
                Console.WriteLine($" Yes! You have {totalMoneyLeft:f2} leva left.");
            }
            else if (price > buget)
            {
                double totalMoneyNeeded = price - buget;
                Console.WriteLine($" Not enough money! You need {totalMoneyNeeded:f2} leva.");
            }
            

        }
    }
}
