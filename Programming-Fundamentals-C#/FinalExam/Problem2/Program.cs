using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\$|%)([A-Z][a-z]{2,})\1: \[(\d+)\]\|\[(\d+)\]\|\[(\d+)\]\|";

            int n = int.Parse(Console.ReadLine());

            Regex regex = new Regex(pattern);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                Match match = regex.Match(text);

                if (match.Success)
                {
                    int firstNum =int.Parse(match.Groups[3].Value);
                    int secondNum = int.Parse( match.Groups[4].Value);
                    int thirdNum = int.Parse( match.Groups[5].Value);

                    char firstChar = (char)firstNum;
                    char secondChar = (char)secondNum;
                    char thirdChar = (char)thirdNum;

                    string word = Char.ToString(firstChar) + Char.ToString(secondChar) + Char.ToString(thirdChar);

                    Console.WriteLine($"{match.Groups[2].Value}: {word}");

                }
                else
                {
                    Console.WriteLine($"Valid message not found!");    
                }
            }
        }
    }
}
