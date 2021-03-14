using System;

namespace _02.Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesInChek = int.Parse(Console.ReadLine());
            int secondesInChek = int.Parse(Console.ReadLine());
            double lenghtOfArea = double.Parse(Console.ReadLine());
            int secundesForHundredMeters = int.Parse(Console.ReadLine());
            int allTimeInSecond = minutesInChek * 60 + secondesInChek;
            double deleyOnMeters = lenghtOfArea / 120;
            double deleyOnTime = deleyOnMeters * 2.5;
            double marinTime = (lenghtOfArea / 100) * secundesForHundredMeters - deleyOnTime;
            if (allTimeInSecond >= marinTime)
            {
                Console.WriteLine($"Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {marinTime:f3}.");
            }
            else if (allTimeInSecond < marinTime)
            {
                double neededTime = marinTime - allTimeInSecond;
                Console.WriteLine($"No, Marin failed! He was {neededTime:f3} second slower.");
            }

        }
    }
}
