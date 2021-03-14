using System;

namespace _9.Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            double pHolydays = double.Parse(Console.ReadLine());
            double hWeekendsInHomeTown = double.Parse(Console.ReadLine());
            double weekends = 48;
            double weekendsInSofia = weekends - hWeekendsInHomeTown;
            double satardayPlayInSofia = weekendsInSofia * 3 / 4;
            double sundayPlysInHome = hWeekendsInHomeTown;
            double holyDaysPlays = pHolydays * 2 / 3;
            double totalPlays = satardayPlayInSofia + sundayPlysInHome + holyDaysPlays;

            
            if (year == "leap")
            {
                 totalPlays *= 1.15;
                
            }
            Console.WriteLine($" {Math.Floor(totalPlays)}");
        } 
    }
}
