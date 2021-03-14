using System;
using System.Diagnostics;

namespace _06.BasketballTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfTheTurnament = Console.ReadLine();
            int basketballGames = int.Parse(Console.ReadLine());
            int gameWin = 0;
            int gameLost = 0;
            int allGames = 0;
            bool sTop = false;
            while (sTop == false)
            {
                 
                 int numberGame = 0;
                 
                for (int i = 1; i <= basketballGames; i++)
                {
                    int pointForOurTeam = int.Parse(Console.ReadLine());
                    int pointForOpponentsTeam = int.Parse(Console.ReadLine());

                   
                    double score = Math.Abs(pointForOurTeam - pointForOpponentsTeam);
                    numberGame++;
                    allGames ++;
                    if (pointForOurTeam > pointForOpponentsTeam)
                    {
                        gameWin++;
                        Console.WriteLine($"Game {numberGame:f0} of tournament {nameOfTheTurnament}: win with {score:f0} points.");
                        
                    }
                    else if (pointForOurTeam < pointForOpponentsTeam)
                    {
                        gameLost++;
                        Console.WriteLine($"Game {numberGame:f0} of tournament {nameOfTheTurnament}: lost with {score:f0} points.");
                        
                    }
                   
                }
                nameOfTheTurnament = Console.ReadLine();
                if (nameOfTheTurnament == "End of tournaments" || nameOfTheTurnament == "End of tournaments ")
                {
                    sTop = true;
                }
                else 
                {
                    basketballGames = int.Parse(Console.ReadLine());
                }              
            }
            if (sTop == true)
            {
                double wins = 1.0 * gameWin * 100 / allGames;
                double losts = 1.0 * gameLost * 100 / allGames;
                Console.WriteLine($"{wins:f2}% matches win");
                Console.WriteLine($"{losts:f2}% matches lost");

            }
        }
    }
}
