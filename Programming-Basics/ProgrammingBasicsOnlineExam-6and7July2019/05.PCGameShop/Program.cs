using System;

namespace _05.PCGameShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int selledGames = int.Parse(Console.ReadLine());
            int countFornite = 0;
            int countHearthstone = 0;
            int countOverwatch = 0;
            int countOthers = 0;
            for (int i = 1; i <= selledGames; i++)
            {
                string gameNames = Console.ReadLine(); //Hearthstone  Fornite  Overwatch  Others 
                if (gameNames == "Hearthstone")
                {
                    countHearthstone++;
                }
                else if (gameNames == "Fornite")
                {
                    countFornite++;
                }
                else if (gameNames == "Overwatch")
                {
                    countOverwatch++;
                }
                else 
                {
                    countOthers++;
                }
            }
            double percentGameHearthstone = 1.0 * countHearthstone * 100 / selledGames;
            double percentGameFornite = 1.0 * countFornite * 100 / selledGames;
            double percentGameOverwatch = 1.0 * countOverwatch * 100 / selledGames;
            double percentGameOthers = 1.0 * countOthers * 100 / selledGames;
            Console.WriteLine($"{percentGameHearthstone:f2}%");
            Console.WriteLine($"{percentGameFornite:f2}%");
            Console.WriteLine($"{percentGameOverwatch:f2}%");
            Console.WriteLine($"{percentGameOthers:f2}%");
        }
    }
}
