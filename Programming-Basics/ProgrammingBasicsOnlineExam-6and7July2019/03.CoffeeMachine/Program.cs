using System;

namespace _03.CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string kineDrinks = Console.ReadLine();
            string sugar = Console.ReadLine();
            int numberDrinks = int.Parse(Console.ReadLine());
            double priceForOneDrink = 0;
            switch (kineDrinks) // "Espresso", "Cappuccino" или "Tea"    "Without", "Normal" или "Extra"
            {
               case "Espresso":
                    if (sugar == "Without")
                    {
                        priceForOneDrink = 0.9;
                    }
                    else if (sugar == "Normal")
                    {
                        priceForOneDrink = 1;
                    }
                    else if (sugar == "Extra")
                    {
                        priceForOneDrink = 1.2;
                    }
                    break;
                case "Cappuccino":
                    if (sugar == "Without")
                    {
                        priceForOneDrink = 1;
                    }
                    else if (sugar == "Normal")
                    {
                        priceForOneDrink = 1.2;
                    }
                    else if (sugar == "Extra")
                    {
                        priceForOneDrink = 1.6;
                    }
                    break;
                case "Tea":
                    if (sugar == "Without")
                    {
                        priceForOneDrink = 0.5;
                    }
                    else if (sugar == "Normal")
                    {
                        priceForOneDrink = 0.6;
                    }
                    else if (sugar == "Extra")
                    {
                        priceForOneDrink = 0.7;
                    }
                    break;
            }
            double priceForAlLDrinks = priceForOneDrink * numberDrinks;
            if (sugar == "Without")
            {
                priceForAlLDrinks *= 0.65;
            }
            if (kineDrinks == "Espresso" && numberDrinks >= 5)
            {
                priceForAlLDrinks *= 0.75;
            }
            if (priceForAlLDrinks > 15)
            {
                priceForAlLDrinks *= 0.8;
            }
            Console.WriteLine($"You bought {numberDrinks} cups of {kineDrinks} for {priceForAlLDrinks:f2} lv.");
        }
    }
}
