using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(=|\/)([A-Za-z]{3,})\1";
            Regex regex = new Regex(pattern);

            var matches = regex.Matches(input);

            int counter = 0;           

            List<string> colections = new List<string>();
           
             foreach (Match matche in matches)
             {

                 string town = matche.Groups[2].Value;
                 colections.Add(town);
                 counter += town.Length;                                
                                 
             }                
             Console.WriteLine($"Destinations: { string.Join(", ", colections)}");
             Console.WriteLine($"Travel Points: {counter}");                             
        }
    }
}
