using System;

namespace _03.Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            const double microBusPrice = 200;
            const double truckPrice = 175;
            const double trainPrice = 120;
            const double convector = 1.0;
            int numbersCargo = int.Parse(Console.ReadLine());
            int tonsCargos = 0;
            int microBus = 0;
            int truck = 0;
            int train = 0;
            for (int i = 1; i <= numbersCargo; i++)
            {
                int number = int.Parse(Console.ReadLine());
                tonsCargos += number;
                if (number <= 3)
                {
                    microBus += number;
                }
                else if (number < 11)
                {
                    truck += number;
                }
                else
                {
                    train += number;
                }
            }
            
            double tottalCostPerTons = convector * ((microBusPrice * microBus) + (truck * truckPrice) + (trainPrice * train)) / tonsCargos;
            double microBusPercent = convector * microBus * 100 / tonsCargos;
            double truckPercent = convector * truck * 100 / tonsCargos;
            double trainPercent = convector * train * 100 / tonsCargos;

            Console.WriteLine($"{tottalCostPerTons:f2}");
            Console.WriteLine($"{microBusPercent:f2}%");
            Console.WriteLine($"{truckPercent:f2}%");
            Console.WriteLine($"{trainPercent:f2}%");             
                   
        }
    }
}
