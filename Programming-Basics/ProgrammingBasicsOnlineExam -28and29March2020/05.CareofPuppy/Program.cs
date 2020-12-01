using System;

namespace _05.CareofPuppy
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodForDogKg = int.Parse(Console.ReadLine());
            int foodForDog = foodForDogKg * 1000;
            string input = Console.ReadLine();
            double eatedFood = 0;
            while (input != "Adopted")
            {
                int inputKilograms = int.Parse(input);
                eatedFood += inputKilograms;
                input = Console.ReadLine();
            }
            if (foodForDog >= eatedFood)
            {
                double foodleft = foodForDog - eatedFood;
                Console.WriteLine($"Food is enough! Leftovers: {foodleft:f0} grams.");
            }
            else
            {
                double neededFood = eatedFood - foodForDog;
                Console.WriteLine($"Food is not enough. You need {neededFood:f0} grams more.");
            }
        }
    }
}
