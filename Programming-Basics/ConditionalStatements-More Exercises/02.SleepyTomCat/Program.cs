using System;

namespace _02.SleepyTomCat
{
    class Program
    {
        static void Main(string[] args)
        {
            double dayOff = double.Parse(Console.ReadLine());
            double workingDaysPerYear = 365 - dayOff;
            double timeForPlay = (workingDaysPerYear * 63) + (dayOff * 127);
            

            if (30000 < timeForPlay)
            {
                double diferenceTimeToPlay = timeForPlay - 30000;
                double hours = diferenceTimeToPlay / 60;
                double minutes = diferenceTimeToPlay % 60;
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{Math.Floor(hours)} hours and {minutes:f0} minutes more for play");
            }
            else
            {
                double diferenceTimeToPlay = 30000 - timeForPlay;
                double hours = diferenceTimeToPlay / 60;
                double minutes = diferenceTimeToPlay % 60;
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{Math.Floor(hours)} hours and {minutes} minutes less for play");
            }
        }
    }
}
