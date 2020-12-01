using System;

namespace _02.MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double neededTimeToClimbsAMeter = double.Parse(Console.ReadLine());
            double timeToClimeDistance = distanceInMeters * neededTimeToClimbsAMeter;
            double deley = Math.Floor(distanceInMeters / 50) * 30;
            
            double totalTime = timeToClimeDistance + deley;
            if (totalTime < recordInSeconds)
            {
                Console.WriteLine($" Yes! The new record is {totalTime:f2} seconds.");
            }
            else
            {
                double neededTime = Math.Abs(recordInSeconds - totalTime);
                Console.WriteLine($"No! He was {neededTime:f2} seconds slower.");
            }

        }
    }
}
