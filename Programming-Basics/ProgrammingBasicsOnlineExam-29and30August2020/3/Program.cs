using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            double sumInAutomt = double.Parse(Console.ReadLine());
            string curcle = Console.ReadLine();
            string yesNo = Console.ReadLine();
            string card = Console.ReadLine();
            double price = 0;
            if (curcle == "five")
            {
                switch (card)  
                {
                    case "Child":
                        price = 7;
                        break;
                    case "Junior":
                        price = 9;
                        break;
                    case "Adult":
                        price = 12;
                        break;
                    case "Profi":
                        price = 18;
                        break;
                }
            }
            else if (curcle == "ten")
            {
                switch (card)
                {
                    case "Child":
                        price = 11;
                        break;
                    case "Junior":
                        price = 16;
                        break;
                    case "Adult":
                        price = 21;
                        break;
                    case "Profi":
                        price = 32;
                        break;
                }
            }
            if (yesNo == "yes")
            {
                price *= 0.8;
            }
            if (price <= sumInAutomt)
            {
                double change = sumInAutomt - price;
                Console.WriteLine($"You bought {card} ticket for {curcle} laps. Your change is {change:f2}lv.");
            }
            else
            {
                double moneyNeeded = price - sumInAutomt;
                Console.WriteLine($"You don't have enough money! You need {moneyNeeded:f2}lv more.");
            }
        }
    }
}
