using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> indexes = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                char index = text[i]; //char.Parse(text[i]);

                if (!indexes.ContainsKey(index))
                {
                    indexes.Add(index, 0);

                }
                indexes[index]++;
            }

            foreach (var index in indexes.OrderBy(k => k.Key))
            {
                Console.WriteLine($"{index.Key}: {index.Value} time/s");
            }
        }
    }
}
