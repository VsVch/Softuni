using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _4.Santa_sSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            string input;            

            string pattern = @"@([A-Z][a-z]+)[^@\-!:>]*!([A-Z])!";

            Regex regex = new Regex(pattern);

            List<string> names = new List<string>();

            while ((input = Console.ReadLine()) != "end")
            {
                string criptedMesseg = string.Empty;

                for (int i = 0; i < input.Length; i++)
                {
                    int newDigit = input[i] - key;

                    char letter = (char)newDigit;

                    criptedMesseg += letter;                    
                }

                Match match = regex.Match(criptedMesseg);

                if (match.Success)
                {
                    string name = match.Groups[1].Value;

                    char behavior = char.Parse(match.Groups[2].Value);

                    if (behavior == 'N')
                    {
                        continue;
                    }
                    else
                    {
                        names.Add(name);
                    }                    
                }
            }
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
