using System;

namespace _03.GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            const double outFall4Price = 39.99;
            const double cSOGPrice = 15.99;
            const double zplinterZellPrice = 19.99;
            const double honored2Price = 59.99;
            const double roverWatchPrice = 29.99;
            const double roverWatchOriginsEditionPrice = 39.99;

            double currentBalance = double.Parse(Console.ReadLine());

            bool isGameTime = false;

            bool isNotFound = false;

            bool isExpenciveGame = false;

            double gamePrice = 0;

            double spendedMoney = 0;

            while (isGameTime != true)
            {
                string currentGame = Console.ReadLine();

                if (currentGame == "Game Time" || currentBalance <= 0)
                {
                    isGameTime = true;
                    break;
                }
                switch (currentGame)
                {
                    case "OutFall 4":
                        if (currentBalance < outFall4Price)
                        {                            
                            break;
                        }
                        gamePrice = outFall4Price;
                        break;
                    case "CS: OG":
                        if (currentBalance < cSOGPrice)
                        {                            
                            break;
                        }
                        gamePrice = cSOGPrice;
                        break;
                    case "Zplinter Zell":
                        if (currentBalance < zplinterZellPrice)
                        {
                            
                            break;
                        }
                        gamePrice = zplinterZellPrice;
                        break;
                    case "Honored 2":
                        if (currentBalance < honored2Price)
                        {
                            
                            break;
                        }
                        gamePrice = honored2Price;
                        break;
                    case "RoverWatch":
                        if (currentBalance < roverWatchPrice)
                        {
                            
                            break;
                        }
                        gamePrice = roverWatchPrice;
                        break;
                    case "RoverWatch Origins Edition":
                        if (currentBalance < roverWatchOriginsEditionPrice)
                        {
                            
                            break;
                        }
                        gamePrice = roverWatchOriginsEditionPrice;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        
                        continue;
                }                 
                if (currentBalance < outFall4Price || currentBalance < cSOGPrice || currentBalance < zplinterZellPrice || currentBalance < honored2Price || currentBalance < roverWatchPrice || currentBalance < roverWatchOriginsEditionPrice)
                {
                    Console.WriteLine("Too Expensive");
                }
                else
                {
                    Console.WriteLine($"Bought { currentGame}");
                }
                currentBalance -= gamePrice;
                spendedMoney += gamePrice;
            }
            if (currentBalance <= 0)
            {
                Console.WriteLine("Out of money!");
            }
            else 
            {
                Console.WriteLine($"Total spent: ${spendedMoney:f2}. Remaining: ${currentBalance:f2}");
            }
        }
    }
}
