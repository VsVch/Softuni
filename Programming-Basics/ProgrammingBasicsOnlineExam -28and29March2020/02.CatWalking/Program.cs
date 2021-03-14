using System;

namespace _02.CatWalking
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesWalkPerDay = int.Parse(Console.ReadLine());
            int numbersWalksPerDay = int.Parse(Console.ReadLine());
            int caloriesPerDay = int.Parse(Console.ReadLine());
            int allMinetsWalkPerDay = numbersWalksPerDay * minutesWalkPerDay;
            int burnetCaloriesPerDay = allMinetsWalkPerDay * 5;
            int neededCaloriesToBurn = caloriesPerDay / 2;
            if (burnetCaloriesPerDay >= neededCaloriesToBurn)
            {
                
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {burnetCaloriesPerDay:f0}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {burnetCaloriesPerDay:f0}.");
            }

        }
    }
}
