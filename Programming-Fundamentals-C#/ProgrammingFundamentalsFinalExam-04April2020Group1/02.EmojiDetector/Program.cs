using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string digitsPattern = @"\d";

            Regex digitRegex = new Regex(digitsPattern);

            int coolThreshold = 1;

            digitRegex.Matches(input)
                .Select(n => n.Value)
                .Select(int.Parse)
                .ToList()
                .ForEach(x =>coolThreshold *= x);            

            string emojisPattern = @"((::)|(\*\*))([A-Z][a-z]{2,})\1";

            Regex emojisRegex = new Regex(emojisPattern);

            var matches = emojisRegex.Matches(input);

            int tottalEmojes = matches.Count;

            List<string> coolEmoges = new List<string>();

            foreach (Match item in matches)
            {
               long coolIndex = item.Value.Substring(2, item.Value.Length - 4)
                    .ToCharArray()
                    .Sum(x =>(int)x);

                if (coolIndex > coolThreshold)
                {
                    coolEmoges.Add(item.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");

            Console.WriteLine($"{tottalEmojes} emojis found in the text. The cool ones are:");

            foreach (var item in coolEmoges)
            {
                Console.WriteLine(item);
            }        

        }
    }
}
