using System;

namespace DefiningClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Bear Gogi = new Bear();
            Gogi.Age = 28;
            Gogi.Name = "gogi";
            Gogi.DaysSinceEaten = 5;

            Bear Bogi = new Bear();
            Bogi.Age = 28;
            Bogi.DaysSinceEaten = 2;
            Bogi.Name = "Bogi";

            Bear Puh = new Bear();
            Puh.Name = "Puh";
            Puh.Age = 25;
            Puh.DaysSinceEaten = 3;

            Bear[] bearZoo = new Bear[3] { Gogi, Bogi, Puh };

            foreach (Bear bear in bearZoo)
            {
                if (bear.DaysSinceEaten >= 3)
                {
                    bear.Eat();
                }

                
            }

            Shirt nike = new Shirt();
            nike.Size = "XXXL";
            nike.Quantity = 55;
            nike.Price = 30;
            nike.Wash();

            Console.WriteLine($"Teniska nike:" +
                $" Size -> {nike.Size}" +
                $" Quantity -> {nike.Quantity}" +
                $" Price -> {nike.Price}");
        }
    }
}
