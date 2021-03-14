using System;

namespace _05.EasterBake
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberEsternCakes = int.Parse(Console.ReadLine());
            double sugarCount = 0;
            double bredCount = 0;
            double numberSugarPakeges = 0;
            double numberBredPakeges = 0;
            int maxAmountOfSugarUsed = int.MinValue;
            int maxAmountOfBredUsed = int.MinValue;
            for (int i = 1; i <= numberEsternCakes; i++)
            {
                int sugarInGrams = int.Parse(Console.ReadLine());
                int bredInGrams = int.Parse(Console.ReadLine());
                sugarCount += sugarInGrams;
                bredCount += bredInGrams;
                if (maxAmountOfSugarUsed < sugarInGrams)
                {
                    maxAmountOfSugarUsed = sugarInGrams;
                }
                if (maxAmountOfBredUsed < bredInGrams)
                {
                    maxAmountOfBredUsed = bredInGrams;
                }
               
            }
            numberSugarPakeges = sugarCount / 950;
            numberBredPakeges = bredCount / 750;
            Console.WriteLine($"Sugar: {Math.Ceiling(numberSugarPakeges)}");
            Console.WriteLine($"Flour: {Math.Ceiling(numberBredPakeges)}");
            Console.WriteLine($"Max used flour is {maxAmountOfBredUsed:f0} grams, max used sugar is {maxAmountOfSugarUsed:f0} grams.");
        }
    }
}
