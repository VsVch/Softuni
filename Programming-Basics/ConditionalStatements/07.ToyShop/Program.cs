using System;
using System.Dynamic;

namespace _07.ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double puzzel = 2.60;
            double tallkingDoll = 3;
            double teddyBears = 4.10;
            double minions = 8.20;
            double truck = 2;
            double tripPrice = double.Parse(Console.ReadLine());
            int numbersOfPuzels = int.Parse(Console.ReadLine());
            int numbersTallkingDolls = int.Parse(Console.ReadLine());
            int numbersTeddybears = int.Parse(Console.ReadLine());
            int numbersMinions = int.Parse(Console.ReadLine());
            int numbersTruck = int.Parse(Console.ReadLine());
            double puzzelsPrice = numbersOfPuzels * puzzel;
            double tallkingDollsPrice = tallkingDoll * numbersTallkingDolls;
            double teddyBearsPrice = teddyBears * numbersTeddybears;
            double minionsprice = minions * numbersMinions;
            double truckPrice = truck * numbersTruck;
            double finalePrice = puzzelsPrice + tallkingDollsPrice + teddyBearsPrice + minionsprice + truckPrice;
            double numbersOfToys = numbersOfPuzels + numbersTallkingDolls + numbersTeddybears + numbersMinions + numbersTruck;
            if (numbersOfToys >= 50)
            {
                // finalePrice = finalePrice * 0.75;
                finalePrice *= 0.75;
            }
            finalePrice *= 0.90;
            if (finalePrice > tripPrice)
            {
                double moneyleft = finalePrice - tripPrice;
                Console.WriteLine($"Yes! {moneyleft:f2} lv left.");
            }
            else
            {
                double neededMoney = tripPrice - finalePrice;
                Console.WriteLine($"Not enough money! {neededMoney:f2} lv needed.");
            }


            
        }
    }
}
