using System;

namespace _07.WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeForMSwim = double.Parse(Console.ReadLine());
            double swimingDistancetime = distance * timeForMSwim;
            double resistance = Math.Floor(distance / 15) * 12.5;

            double swimingTimeWhitResistance = swimingDistancetime + resistance;
            if (recordInSeconds > swimingTimeWhitResistance)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {(swimingTimeWhitResistance):f2} seconds.");
            }
            else
            {
                double neededSecunds = swimingTimeWhitResistance - recordInSeconds;
                Console.WriteLine($"No, he failed! He was {(neededSecunds):f2} seconds slower.");
            }
                        
        }
    }
}
