using System;
using System.Threading;

namespace _04.Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfPlayer = Console.ReadLine();
            int scoreHit = 0;
            int count = 0;
            int score = 0;
            int countFallShots = 0;
            for (int i = 301; i >= 0; i -= score)
            {
                string area = Console.ReadLine();
                if (area == "Retire")
                {
                    Console.WriteLine($"{nameOfPlayer} retired after {countFallShots} unsuccessful shots.");
                    break;
                }
                score = int.Parse(Console.ReadLine());
                int lastHit = 0;
                if (area == "Single") // ("Single", "Double" или "Triple")
                {
                    scoreHit += score * 1;
                    lastHit = score * 1;
                    score = score * 1;
                }
                else if (area == "Double")
                {
                    scoreHit += score * 2;
                    lastHit = score * 2;
                    score = score * 2;
                }
                else if (area == "Triple")
                {
                    scoreHit += score * 3;
                    lastHit = score * 3;
                    score = score * 3;
                }
                count++;
                if (scoreHit == 301)
                {
                    Console.WriteLine($"{nameOfPlayer} won the leg with {count - countFallShots} shots.");
                    break;
                }
                else if (scoreHit > 301)
                {
                    scoreHit -= lastHit;
                    score -= lastHit;
                    countFallShots ++;
                }

            }            
            
            

        }
    }
}
