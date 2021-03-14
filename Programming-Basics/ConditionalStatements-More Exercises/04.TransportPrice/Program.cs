using System;

namespace _04.TransportPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            double nKilometers = double.Parse(Console.ReadLine());
            string twentyFourHours = (Console.ReadLine());
            double taxiDayTraveling = (nKilometers * 0.79) + 0.70; 
            double taxiNightTraveling = (nKilometers * 0.9) + 0.70;
            if (twentyFourHours == "day" && nKilometers < 20)
            {
                Console.WriteLine(taxiDayTraveling);
            }
            else if (twentyFourHours == "night" && nKilometers < 20)
            {
                Console.WriteLine($"{taxiNightTraveling:f2}");
            }
            else if (nKilometers >= 100)
            {
                double trainTraveling = nKilometers * 0.06;
                Console.WriteLine($"{trainTraveling:f2}");
            }
            else
            {
                double bussTraveling = nKilometers * 0.09;
                Console.WriteLine($"{bussTraveling:f2}");
            }
        }
    }
}
