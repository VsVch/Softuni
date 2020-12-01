using System;

namespace _05.Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededHours = double.Parse(Console.ReadLine());
            double workingDays = double.Parse(Console.ReadLine());
            double nombersEmploisWorkinExtraTime = double.Parse(Console.ReadLine());
            double workingHours = workingDays * 8 * 0.9;
            double extraWorkingHours = workingDays * nombersEmploisWorkinExtraTime * 2;
            double totalHours = workingHours + extraWorkingHours;
            if (totalHours >= neededHours)
            {
                double hoursLeft = Math.Floor(totalHours) - neededHours;
                Console.WriteLine($"Yes!{hoursLeft} hours left.");
            }
            else
            {
                double hoursNeed = neededHours - Math.Floor(totalHours);
                Console.WriteLine($"Not enough time!{hoursNeed} hours needed.");    
            }

        }
    }
}
