using System;

namespace _04.FoodforPets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double food = double.Parse(Console.ReadLine());
            double foodForDog = 0;
            double foodForCat = 0;
            double cookiesReward = 0;
            double thirdDayFood = 0;
            

            for (int i = 1; i <= days; i++)
            {
                int foodeatenByDog = int.Parse(Console.ReadLine());
                int foodeatenByCat = int.Parse(Console.ReadLine());
                if (i % 3 == 0)
                {
                    cookiesReward += (foodeatenByDog + foodeatenByCat) * 0.1;
                    thirdDayFood += foodeatenByDog + foodeatenByCat + (cookiesReward);
                }
                foodForDog += foodeatenByDog;
                foodForCat += foodeatenByCat;
                

            }
            double totalFood = foodForDog + foodForCat;
            double percentEatenFood = totalFood * 100 / food;
            double percentEatenByDog = foodForDog * 100 / totalFood;
            double percentEatenByCat = foodForCat * 100 / totalFood;
            Console.WriteLine($"Total eaten biscuits: {cookiesReward:f0}gr.");
            Console.WriteLine($"{percentEatenFood:f2}% of the food has been eaten.");            
            Console.WriteLine($"{percentEatenByDog:f2}% eaten from the dog.");
            Console.WriteLine($"{percentEatenByCat:f2}% eaten from the cat.");
        }
    }
}
