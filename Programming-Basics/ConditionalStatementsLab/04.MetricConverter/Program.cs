using System;

namespace _04.MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double distance = double.Parse(Console.ReadLine());
            string inputUnit = Console.ReadLine();
            string outputUnit = Console.ReadLine();
            if (inputUnit == "mm" && outputUnit == "m")
            {
                distance /= 1000;
            }
            else if (inputUnit == "m" && outputUnit == "mm")
            {
                distance *= 1000;
            }
            else if (inputUnit == "mm" && outputUnit == "cm")
            {
                distance /= 10;
            }
            else if (inputUnit == "cm" && outputUnit == "mm")
            {
                distance *= 10;
            }
            else if (inputUnit == "cm" && outputUnit == "m")
            {
                distance /= 100;
            }
            else if (inputUnit == "m" && outputUnit == "cm")
            {
                distance *= 100;
            }
            Console.WriteLine($"{distance:f3}");
        }
        
    }
}
