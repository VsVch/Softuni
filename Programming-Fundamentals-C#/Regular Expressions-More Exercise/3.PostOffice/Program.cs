using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3.PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("|");

            string firstPartPattern = @"([#$%.&])([A-Z]+)\1";

            Regex regexOne = new Regex(firstPartPattern);

            Match matchOne = regexOne.Match(input[0]);

            if (matchOne.Success)
            {
                string capitalsWord = matchOne.Groups[2].Value;

                string secondPartPattern = @"([0-9][0-9]):([0-9][0-9])";

                Regex regexTwo = new Regex(secondPartPattern);

                MatchCollection machesTwo = regexTwo.Matches(input[1]);

                Dictionary<char, int> wordsCollections = new Dictionary<char, int>();

                for (int i = 0; i < capitalsWord.Length; i++)
                {
                    int symbol = capitalsWord[i];

                    for (int j = 0; j <machesTwo.Count; j++)
                    {
                        int letter = int.Parse(machesTwo[j].Groups[1].Value);
                        int letterLenght = int.Parse(machesTwo[j].Groups[2].Value);

                        if (symbol == letter)
                        {
                            wordsCollections.Add((char)symbol, letterLenght +1);
                            break;
                            
                        }
                    }
                }
                string[] text = input[2].Split(" ",StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in wordsCollections)
                {
                    char wordChar = word.Key;
                    int wordCharLenght = word.Value;

                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i].Contains(wordChar) && text[i].Length == wordCharLenght)
                        {
                            string theWord = text[i];
                            Console.WriteLine(theWord);
                            break;
                        }
                    }
                  
                }
            }
        }
    }
}
