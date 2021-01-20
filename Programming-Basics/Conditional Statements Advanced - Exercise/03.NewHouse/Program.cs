using System;

namespace _03.NewHouse
{
    class Program
    {
        static double Roses = 5;
        static double Dahlias = 3.8;
        static double Tulips = 2.8;
        static double Narcissus = 3;
        static double Gladiolus = 2.5;
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            double numberFlowers = double.Parse(Console.ReadLine());
            double buget = double.Parse(Console.ReadLine());
            double finalePrice = 0;
            switch (flowers)
            {
                case "Roses":
                    finalePrice = numberFlowers * Roses;
                    if (numberFlowers > 80)
                    {
                        finalePrice *= 0.9;
                    }
                break;
                case "Dahlias":
                    finalePrice = numberFlowers * Dahlias;
                    if (numberFlowers > 90)
                    {
                        finalePrice *= 0.85;
                    }
                    break;
                case "Tulips":
                    finalePrice = numberFlowers * Tulips;
                    if (numberFlowers > 80)
                    {
                        finalePrice *= 0.85;
                    }
                    break;
                case "Narcissus":
                    finalePrice = numberFlowers * Narcissus;
                    if (numberFlowers < 120)
                    {
                        finalePrice *= 1.15;
                    }
                    break;
                case "Gladiolus":
                    finalePrice = numberFlowers * Gladiolus;
                    if (numberFlowers < 80)
                    {
                        finalePrice *= 1.20;
                    }
                    break;
            }            
            if (buget >= finalePrice)
            {
                double totalMoneyLeft = buget - finalePrice;
                Console.WriteLine($"Hey, you have a great garden with {numberFlowers} {flowers} and {totalMoneyLeft:f2} leva left.");
            }
            else if (finalePrice > buget)
            {
                double totalNeededMoney = finalePrice - buget;
                Console.WriteLine($"Not enough money, you need {totalNeededMoney:f2} leva more.");
            }

        }
    }
}
