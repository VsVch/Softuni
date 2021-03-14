using System;

namespace _4Backin30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int totalTimePlusDelay = (hours * 60) + minutes + 30;
            int realHours = totalTimePlusDelay / 60;
            int realMinutes = totalTimePlusDelay - (realHours * 60);
            int nightRestartHours = 0;
            int minutesLeft = 0;
            if (realMinutes <= 59)
            {
                minutesLeft = realMinutes;
            }
            else if (realMinutes == 60)
            {
                nightRestartHours += 1;
            }         
            if (realHours <= 23)
            {
                nightRestartHours = realHours;
            }
            else if (realHours == 24)
            {
                nightRestartHours = 0;
            }
           

            Console.WriteLine($"{nightRestartHours}:{minutesLeft:d2}");
        }
    }
}
