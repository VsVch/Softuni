using System;

namespace _03.Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1ви ред: X кв.м е лозето – цяло число в интервала[10 … 5000] - 650
            // 2ри ред: Y грозде за един кв.м – реално число в интервала[0.00 … 10.00] - 2
            // 3ти ред: Z нужни литри вино – цяло число в интервала[10 … 600] - 175
            // 4ти ред: брой работници – цяло число в интервала[1 … 20] - 3
            
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double z = double.Parse(Console.ReadLine());
            double numbersOfWorkers = double.Parse(Console.ReadLine());
            double grapes = x * y;
            double vineyardForVine = (grapes * 0.4) / 2.5;
            if (z > vineyardForVine)
            {
                double neededVine = z - vineyardForVine;
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(neededVine)} liters wine needed.");
            }
            else
            {
                double neededVine = vineyardForVine - z;
                double vinePerWorker = neededVine / numbersOfWorkers;

                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(vineyardForVine)} liters.");
                Console.WriteLine($"{Math.Ceiling(neededVine)} liters left -> {Math.Ceiling(vinePerWorker)} liters per person.");
            }

            


        }
    }
}
