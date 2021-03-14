using System;
using System.Collections.Generic;

namespace _04.CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> locations 
                = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) // continents, countries and their cities
            {
                var tokens = Console.ReadLine().Split(" ");

                var continent = tokens[0];
                var countrie = tokens[1];
                var citie = tokens[2];

                if (!locations.ContainsKey(continent))
                {
                    locations.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!locations[continent].ContainsKey(countrie))
                {
                    locations[continent].Add(countrie, new List<string>());
                }
                locations[continent][countrie].Add(citie);
            }

            foreach (var continent in locations)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var countrie in continent.Value)
                {
                    Console.Write($"  {countrie.Key} -> ");

                    int cityCounter = 0;

                    foreach (var city in countrie.Value)
                    {
                        cityCounter++;
                        
                        if (countrie.Value.Count == cityCounter)
                        {
                            Console.Write($"{city}");
                        }
                        else
                        {
                            Console.Write($"{city}, ");
                        }
                        
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
