using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> dwarfsList = new Dictionary<string, Dictionary<string, double>>();

            string input;

            while ((input = Console.ReadLine()) != "Once upon a time") // {dwarfName} <:> {dwarfHatColor} <:> {dwarfPhysics}
            {
                string[] tokens = input.Split(" <:> ");

                string dwarfName = tokens[0];
                string dwarfHatColor = tokens[1];
                double dwarfPhysics = double.Parse(tokens[2]);

                if (!dwarfsList.ContainsKey(dwarfName))
                {
                    dwarfsList.Add(dwarfName, new Dictionary<string, double>());
                }
                if (!dwarfsList[dwarfName].ContainsKey(dwarfHatColor))
                {
                    dwarfsList[dwarfName].Add(dwarfHatColor, dwarfPhysics);
                }

                if (dwarfsList[dwarfName][dwarfHatColor] < dwarfPhysics)
                {
                    dwarfsList[dwarfName][dwarfHatColor] = dwarfPhysics;
                }
            }        
                

            foreach (var dwarf in dwarfsList.OrderByDescending(x => x.Value.Values.Max()).ThenByDescending(x => x.Value.Count())) // (Yellow) Sasho <-> 4500
            {
                foreach (var item in dwarf.Value)
                {
                    Console.WriteLine($"({item.Key}) {dwarf.Key} <-> {item.Value}");
                }
            }
        }
    }
}
