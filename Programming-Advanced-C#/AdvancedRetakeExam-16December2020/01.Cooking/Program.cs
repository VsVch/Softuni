using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>
                (Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Stack<int> ingredientes = new Stack<int>
                (Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Dictionary<string, Dictionary<int, int>> cooking = new Dictionary<string, Dictionary<int, int>>()
            {
                {"Bread" , new Dictionary<int, int>(){ { 25, 0} } },
                {"Cake" , new Dictionary<int, int>(){ { 50, 0} } },
                {"Pastry" , new Dictionary<int, int>(){ { 75,0} } },
                {"Fruit Pie" , new Dictionary<int, int>(){ { 100, 0} } },

            };

            while (liquids.Count != 0 && ingredientes.Count != 0)
            {
                int liquid = liquids.Dequeue();
                int ingredient = ingredientes.Pop();

                int recept = liquid + ingredient;

                if (cooking["Bread"].ContainsKey(recept))
                {
                    cooking["Bread"][recept]++;
                }
                else if (cooking["Cake"].ContainsKey(recept))
                {
                    cooking["Cake"][recept]++;
                }
                else if (cooking["Pastry"].ContainsKey(recept))
                {
                    cooking["Pastry"][recept]++;
                }
                else if (cooking["Fruit Pie"].ContainsKey(recept))
                {
                    cooking["Fruit Pie"][recept]++;
                }
                else
                {
                    ingredient += 3;
                    ingredientes.Push(ingredient);                    
                }
            }

            bool isNotEnoughtFood = false;

            foreach (var coock in cooking) 
            {
                foreach (var item in coock.Value)
                {
                    if (item.Value < 1)
                    {
                        isNotEnoughtFood = true;
                    }
                }
            }

            if (isNotEnoughtFood)
            {
                Console.WriteLine($"Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            else
            {
                Console.WriteLine($"Wohoo! You succeeded in cooking all the food!");
            }
            if (liquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }
            if (ingredientes.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredientes)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var coock in cooking.OrderBy(c => c.Key))
            {
                foreach (var item in coock.Value)
                {
                    Console.WriteLine($"{coock.Key}: {item.Value}");
                }
            }

        }
    }
}
