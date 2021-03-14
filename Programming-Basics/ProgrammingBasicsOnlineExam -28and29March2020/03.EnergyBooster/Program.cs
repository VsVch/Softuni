using System;

namespace _03.EnergyBooster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruits = Console.ReadLine();
            string sizeOfSets = Console.ReadLine();
            int numberOrderedSets = int.Parse(Console.ReadLine());
            double price = 0;
            switch (fruits)
            {
                case "Watermelon":
                    if (sizeOfSets == "small")
                    {
                        price = 2 * 56 * numberOrderedSets;
                    }
                    else if (sizeOfSets == "big")
                    {
                        price = 5 * 28.7 * numberOrderedSets;
                    }
                    break;
                case "Mango":
                    if (sizeOfSets == "small")
                    {
                        price = 2 * 36.66 * numberOrderedSets;
                    }
                    else if (sizeOfSets == "big")
                    {
                        price = 5 * 19.6 * numberOrderedSets;
                    }
                    break;
                case "Pineapple":
                    if (sizeOfSets == "small")
                    {
                        price = 2 * 42.1 * numberOrderedSets;
                    }
                    else if (sizeOfSets == "big")
                    {
                        price = 5 * 24.8 * numberOrderedSets;
                    }
                    break;
                case "Raspberry":
                    if (sizeOfSets == "small")
                    {
                        price = 2 * 20 * numberOrderedSets;
                    }
                    else if (sizeOfSets == "big")
                    {
                        price = 5 * 15.2 * numberOrderedSets;
                    }
                    break;

            }
            if (price >= 400 && price <= 1000)
            {
                double priceWhitDiscount = price - (price * 0.15);
                Console.WriteLine($"{priceWhitDiscount:f2} lv.");
            }
            else if (price > 1000)
            {
                double priceWhitDiscount = price - (price * 0.5);
                Console.WriteLine($"{priceWhitDiscount:f2} lv.");
            }
            else
            {
                Console.WriteLine($"{price:f2} lv.");
            }
            
        }
    }
}
