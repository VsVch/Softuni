using System;
using System.Diagnostics;

namespace _05.Everest
{
    class Program
    {
        static void Main(string[] args)
        {
            string yesNo = Console.ReadLine();
            int climbsMeters = int.Parse(Console.ReadLine());
            int days = 0;
            int reachedMeters = 5364;
            bool sTop = false;
            while (sTop != true)
            {                
                days++;
                
                if (days >= 5)
                {
                    Console.WriteLine($"Failed!");
                    Console.WriteLine($"{reachedMeters}");
                    sTop = true;
                    break;
                }
                reachedMeters += climbsMeters;
                if (reachedMeters >= 8848)
                {
                    Console.WriteLine($"Goal reached for {days} days!");
                    sTop = true;
                    break;
                }
                yesNo = Console.ReadLine();
                if (yesNo == "END")
                {
                    Console.WriteLine($"Failed!");
                    Console.WriteLine($"{reachedMeters}");
                    sTop = true;
                    break;
                }
                climbsMeters = int.Parse(Console.ReadLine());               
            }
           
        }
    }
}
