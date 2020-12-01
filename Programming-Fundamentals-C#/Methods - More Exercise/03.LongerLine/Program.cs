using System;

namespace _03.LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 2; i++)
            {
                int X1 = int.Parse(Console.ReadLine()); 
                int Y1 = int.Parse(Console.ReadLine()); 
                int X2 = int.Parse(Console.ReadLine()); 
                int Y2 = int.Parse(Console.ReadLine());
                int X3 = int.Parse(Console.ReadLine());
                int Y3 = int.Parse(Console.ReadLine());
                int X4 = int.Parse(Console.ReadLine());
                int Y4 = int.Parse(Console.ReadLine());
                FoundClosestPointToNullNull(X1, Y1, X2, Y2, X3, Y3, X4, Y4);
            }
        }
        public static void FoundClosestPointToNullNull(int X1, int Y1, int X2, int Y2, int X3, int Y3, int X4, int Y4)
        {     
            
             if (Math.Abs((X1 * X1) + (Y1 * Y1) + (X2 * X2) + (Y2 + Y2)) >= ((X3 * X3) + (Y3 * Y3) + (X4 * X4) + (Y4 + Y4)))
             {
                 Console.WriteLine($"({X2}, {Y2})({X1}, {Y1})");
             }
             else if (Math.Abs((X1 * X1) + (Y1 * Y1) + (X2 * X2) + (Y2 + Y2)) < ((X3 * X3) + (Y3 * Y3) + (X4 * X4) + (Y4 + Y4)))
            {
                 Console.WriteLine($"({X4}, {Y4})({X3}, {Y3})");
             }          
        }
    }
}
