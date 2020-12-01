using System;
using System.Xml.Schema;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            const double strawberryPrice = 3.5;
            const double blueberriesPrice = 5.0;
            int rowsNumber = int.Parse(Console.ReadLine());
            int linesNumber = int.Parse(Console.ReadLine());
            int strawberryCount = 0;
            int blueberryCount = 0;
            for (int i = 1; i <= rowsNumber; i++)
            {
                for (int j = 1; j <= linesNumber; j++)
                {
                    if (i % 2 != 0)
                    {
                        strawberryCount++;
                    }
                    if (i % 2 == 0 && j % 3 != 0)
                    {
                        blueberryCount++;
                    }
                }
            }
            double priceOfStrawberry = strawberryCount * strawberryPrice;
            double priceOfBlueberry = blueberryCount * blueberriesPrice;
            double totalPrice = (priceOfBlueberry + priceOfStrawberry) * 0.8;
            Console.WriteLine($"Total: {totalPrice:f2} lv.");


        }
    }
}
