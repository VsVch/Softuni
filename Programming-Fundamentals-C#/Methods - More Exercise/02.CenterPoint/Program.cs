using System;

namespace _02.CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double X1 = double.Parse(Console.ReadLine()); // X1, Y1, X2 and Y2
            double Y1 = double.Parse(Console.ReadLine()); // X1, Y1, X2 and Y2
            double X2 = double.Parse(Console.ReadLine()); // X1, Y1, X2 and Y2
            double Y2 = double.Parse(Console.ReadLine()); // X1, Y1, X2 and Y2
            FoundClosestPointToNullNull(X1, Y1, X2, Y2);
        }
        public static void FoundClosestPointToNullNull(double X1, double Y1, double X2, double Y2)
        {
           

            if (Math.Abs((X1 * X1) + (Y1 * Y1)) <= ((X2 *X2) + (Y2 + Y2)))
            {
                Console.WriteLine($"({X1}, {Y1})");
            }
            else if (Math.Abs((X1 * X1) + (Y1 * Y1)) > ((X2 * X2) + (Y2 + Y2)))
            {
                Console.WriteLine($"({X2}, {Y2})");
            }            
        }
    }
}
