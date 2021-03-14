using System;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> colections = new Dictionary<char, int>();


            foreach (var letter in input)
            {
                if (letter == ' ')
                {
                    continue;
                }
                if (!colections.ContainsKey(letter))
                {
                    colections.Add(letter, 0);
                }
                colections[letter]++;
            }
            foreach (var item in colections)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
