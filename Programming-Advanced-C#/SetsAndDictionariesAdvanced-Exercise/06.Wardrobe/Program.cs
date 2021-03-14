using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] separator = new string[] {" -> ","," };

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
               var input = Console.ReadLine();

                var tokens = input.Split(separator, StringSplitOptions.RemoveEmptyEntries); // "{color} -> {item1},{item2},{item3}…"

                string color = tokens[0];

                for (int j = 1; j < tokens.Length; j++)
                {
                    string item = tokens[j];

                    if (!wardrobe.ContainsKey(color))
                    {
                        wardrobe.Add(color, new Dictionary<string, int>());
                    }
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item, 0);
                    }

                    wardrobe[color][item]++;
                }

            }

            string[] dreesToFound = Console.ReadLine().Split(" ");

            string neededColor = dreesToFound[0];
            string neededDress = dreesToFound[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var drees in color.Value)
                {
                    if (color.Key == neededColor && drees.Key == neededDress) 
                    {
                        Console.WriteLine($"* {drees.Key} - {drees.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {drees.Key} - {drees.Value}");
                    }                   

                }
            }
        }
    }
}
