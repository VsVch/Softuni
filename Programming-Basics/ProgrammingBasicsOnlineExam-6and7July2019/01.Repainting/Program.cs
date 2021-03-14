using System;

namespace _01.Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            int neededQuantlityNylon = int.Parse(Console.ReadLine());
            int neededQuantlityPaint = int.Parse(Console.ReadLine());
            int quantlityDiluent= int.Parse(Console.ReadLine());
            int hoursWork = int.Parse(Console.ReadLine());
            double priceForNylon = (neededQuantlityNylon + 2) * 1.0 * 1.5;
            double priceForPaint = neededQuantlityPaint * 1.1 * 1.0 * 14.5;
            double priceForDiluent = quantlityDiluent * 1.0 * 5;
            double priceForAllMAterials = priceForNylon + priceForPaint + priceForDiluent + 0.4;
            double workExpences = priceForAllMAterials * 30 / 100 * hoursWork;
            double totalPrice = workExpences + priceForAllMAterials;
            Console.WriteLine($"Total expenses: {totalPrice:f2} lv.");

        }   
    }
}
