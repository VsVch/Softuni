using System;

namespace _06.Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double numberOfDays = double.Parse(Console.ReadLine());
            int kilogramFood = int.Parse(Console.ReadLine());
            double dogFoodPerDay = double.Parse(Console.ReadLine());
            double catFoodPerDay = double.Parse(Console.ReadLine());
            double tortlesFoodPerDay = double.Parse(Console.ReadLine());
            double neededDogFoot = numberOfDays * dogFoodPerDay;
            double neededKatFoot = numberOfDays * catFoodPerDay;
            double neededTortlesFoot = numberOfDays * tortlesFoodPerDay / 1000;
            double totalFood = neededDogFoot + neededKatFoot + neededTortlesFoot;
            if (kilogramFood >= totalFood)
            {
                double foodLeft = kilogramFood - totalFood;
                Console.WriteLine($"{Math.Floor(foodLeft)} kilos of food left.");
            }
            else
            {
                double shortegFood = totalFood - kilogramFood;
                Console.WriteLine($"{Math.Ceiling(shortegFood)} more kilos of food are needed.");
            }
        }
    }
}
