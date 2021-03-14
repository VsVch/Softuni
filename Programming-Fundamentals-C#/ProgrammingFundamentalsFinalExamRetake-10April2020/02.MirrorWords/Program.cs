using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(#|@)([A-Za-z]{3,})\1{2}([A-Za-z]{3,})\1";

            string text = Console.ReadLine();

            Regex regex = new Regex(pattern);

            var matches = regex.Matches(text);

            Dictionary<string, string> collections = new Dictionary<string, string>();

            int collectionCounter = 0;

            int counter = 0;

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
                Environment.Exit(0);
            }
            else
            {
                foreach (Match match in matches)
                {
                    string firstWord = match.Groups[2].Value;
                    string reverceWord = match.Groups[3].Value;
                    string secondWord = string.Empty;
                    counter = matches.Count;
                    for (int i = reverceWord.Length - 1; i >= 0; i--)
                    {
                        secondWord += reverceWord[i];
                    }

                    if (firstWord == secondWord)
                    {
                        collectionCounter++;
                        collections.Add(firstWord, reverceWord);
                    }
                    

                }
            }
            Console.WriteLine($"{counter} word pairs found!");
            if (collections.Count == 0)
            {
                
                Console.WriteLine("No mirror words!");
            }
            else
            {
                int count = 0;               
                Console.WriteLine("The mirror words are:");

                foreach (var item in collections)
                {
                    count++;                 
                    

                    if (count == collectionCounter)
                    {
                       
                        Console.Write($"{item.Key} <=> {item.Value}");
                        break;
                    }
                    Console.Write($"{item.Key} <=> {item.Value}, ");
                }
            }         
                 
        }
    }
}
