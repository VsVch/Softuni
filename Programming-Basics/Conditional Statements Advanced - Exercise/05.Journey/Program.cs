using System;

namespace _05.Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double buget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
                       
            switch (season)
            {
                case "summer":
                    if (buget <= 100)
                    {
                        buget *= 0.3;
                        Console.WriteLine("Somewhere in Bulgaria");
                        Console.WriteLine($"Camp - {buget:f2}");
                    }
                    else if (buget <= 1000)
                    {
                        buget *= 0.4;
                        Console.WriteLine("Somewhere in Balkans");
                        Console.WriteLine($"Camp - {buget:f2}");
                    }
                    else
                    {
                        buget *= 0.9;
                        Console.WriteLine("Somewhere in Europe");
                        Console.WriteLine($"Hotel - {buget:f2}");
                    }
                    break;
                case "winter":
                    if (buget <= 100)
                    {
                        buget *= 0.7;
                        Console.WriteLine("Somewhere in Bulgaria");
                        Console.WriteLine($"Hotel - {buget:f2}");
                    }
                    else if (buget <= 1000)
                    {
                        buget *= 0.8;
                        Console.WriteLine("Somewhere in Balkans");
                        Console.WriteLine($"Hotel - {buget:f2}");
                    }
                    else
                    {
                        buget *= 0.9;
                        Console.WriteLine("Somewhere in Europe");
                        Console.WriteLine($"Hotel - {buget:f2}");
                    }
                    break;
            }
        }
    }
}
