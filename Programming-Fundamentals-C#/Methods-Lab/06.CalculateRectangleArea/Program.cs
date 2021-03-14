using System;

namespace _06.CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double area = AreaOfrectangle(width, height);

            Console.WriteLine(area);
        }

        static double AreaOfrectangle(double width, double height)
        {
            return width * height;
        }
    }
}
