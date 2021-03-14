using System;

namespace _05.TennisRanklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberTurnament = int.Parse(Console.ReadLine());
            int startPointsInRanking = int.Parse(Console.ReadLine());
            int points = 0;
            int winTurnaments = 0;
            for (int i = 1; i <= numberTurnament; i++) //"W", "F" или "SF"
            {
                string stageOfTurnament = Console.ReadLine();
                if (stageOfTurnament == "W")
                {
                    points += 2000;
                    winTurnaments++;
                }
                else if (stageOfTurnament == "F")
                {
                    points += 1200;
                }
                else if (stageOfTurnament == "SF")
                {
                    points += 720;
                }
            }
            int finalePoints = startPointsInRanking + points;
            int averegePoint = points / numberTurnament;
            double percentWinRate = 1.0 * winTurnaments * 100 / numberTurnament;
            Console.WriteLine($"Final points: {finalePoints}");            
            Console.WriteLine($"Average points: {averegePoint}");
            Console.WriteLine($"{percentWinRate:f2}%");
        }
    }
}
