using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Program
    {
        public static object Redex { get; private set; }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = new List<string>();

            Dictionary<string, List<string>> codeTexts = new Dictionary<string, List<string>>();                      
            
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int key = 0;

                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == 's' || input[j] == 't'||
                        input[j] == 'a' || input[j] == 'r'||
                        input[j] == 'S' || input[j] == 'T' ||
                        input[j] == 'A' || input[j] == 'R') // [s, t, a, r]
                    {
                        key++;
                    }
                }

                string decriptedText = string.Empty;

                for (int j = 0; j < input.Length; j++)
                {
                    int number = input[j] - key;

                    char letter =(char) number;

                    decriptedText += letter;
                }
                string pattern = @"@([A-Z][a-z]+)\d*:(\d+)!([AD])!->(\d+)";

                Regex regex = new Regex(pattern);

                Match match = regex.Match(decriptedText);

                if (match.Success)//planet name, population, attack type ('A', as attack or 'D', as destruction) and soldier count.
                {
                    string name = match.Groups[1].Value;
                    int popolations = int.Parse(match.Groups[2].Value);
                    char attackType = char.Parse(match.Groups[3].Value);
                    int soldersCount = int.Parse(match.Groups[4].Value);

                    string type = string.Empty;

                    if (attackType == 'A')
                    {
                        type = "Attacked";                    
                    }
                    else if(attackType == 'D')
                    {
                        type = "Destroyed";                        
                    }                    

                    if (!codeTexts.ContainsKey(type))
                    {
                        codeTexts.Add("Attacked", new List<string>());
                        codeTexts.Add("Destroyed", new List<string>());
                    }                
                    
                    codeTexts[type].Add(name);
                    
                    
                }
            }

            foreach (var text in codeTexts.OrderBy(k=>k.Key))
            {
                Console.WriteLine($"{text.Key} planets: {text.Value.Count}");

                foreach (var kvp in text.Value.OrderBy(v => v))
                {
                    Console.WriteLine($"-> {kvp}");
                }
                
            }
        }
    }
}
