using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<string, int> keyMaterisls = new Dictionary<string, int>() {};

            Dictionary<string, int> junkMaterisls = new Dictionary<string, int>();

            keyMaterisls["shards"] = 0;
            keyMaterisls["fragments"] = 0;
            keyMaterisls["motes"] = 0;

            bool hasToBreak = false;

            while (true)           
            {
                string[] input = Console.ReadLine().Split(" ");
                
                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();

                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        keyMaterisls[material] += quantity;

                        if (keyMaterisls[material] >= 250)
                        {
                            keyMaterisls[material] -= 250;
                            if (material == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                            }
                            else if (material == "fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                            }
                            else if (material == "motes")
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                            }
                            hasToBreak = true;
                            break;
                        }
                        
                    }
                    else
                    {
                        if (!junkMaterisls.ContainsKey(material))
                        {
                            junkMaterisls.Add(material, 0);
                        }
                        junkMaterisls[material] += quantity;
                    }
                }
                if (hasToBreak)
                {
                    break;
                }               
               
            }
            Dictionary<string, int> filteredKeyMaterials = keyMaterisls
                .OrderByDescending(v => v.Value)
                .ThenBy(k => k.Key)
                .ToDictionary(a =>a.Key, a=> a.Value);

            foreach (var kvp in filteredKeyMaterials)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junkMaterisls.OrderBy(k => k.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

        }
    }
}
