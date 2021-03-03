using System;

namespace _04.PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string pizzaName = Console.ReadLine().Split(" ")[1];

                string[] input = Console.ReadLine().Split(" ");


                string flourType = input[1];
                string bakingTechnique = input[2];
                int weight = int.Parse(input[3]);

                Dough dough = new Dough(flourType, bakingTechnique, weight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string toppingData;
                while ((toppingData = Console.ReadLine()) != "END")
                {
                    string[] toppingsInfo = toppingData.Split(" ");

                    var toppingName = toppingsInfo[1];
                    var toppingWeight = int.Parse(toppingsInfo[2]);

                    Topping topping = new Topping(toppingName, toppingWeight);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():f2} Calories.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
