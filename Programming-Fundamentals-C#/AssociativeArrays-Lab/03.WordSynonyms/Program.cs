using System;
using System.Collections.Generic;
using System.Globalization;

namespace _03.WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfWords = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> dictonary = new Dictionary<string, List<string>>();

            for (int i = 0; i < numberOfWords; i++)
            {
                string word = Console.ReadLine();
                string synonim = Console.ReadLine();

                if (dictonary.ContainsKey(word))
                {
                    dictonary[word].Add(synonim);
                }
                else
                {
                    dictonary.Add(word, new List<string> { synonim });
                }
            }

            foreach (var word in dictonary)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
            }
        }   
    }
}
