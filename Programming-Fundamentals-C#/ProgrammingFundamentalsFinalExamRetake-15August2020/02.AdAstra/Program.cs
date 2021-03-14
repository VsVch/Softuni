using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"([#\|])(?<name>[A-Za-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})*\1(?<calories>\d{1,5})\1";

            Regex regex = new Regex(pattern);

            var matches = regex.Matches(text);

            int calories = 0;

            int maxCaloriesPerDay = 2000;
            
            for (int i = 0; i < matches.Count; i++)
            {
                string name = matches[i].Groups[2].Value;
                string date = matches[i].Groups[3].Value;
                int calorie = int.Parse(matches[i].Groups[4].Value);
                calories += calorie;                
            }                 

            int totallDay = calories / maxCaloriesPerDay;

            Console.WriteLine($"You have food to last you for: {totallDay} days!");           
            
            foreach (Match match in matches)
            {
                Console.WriteLine($"Item: {match.Groups[2].Value}, Best before: " +
                    $"{match.Groups[3].Value}, Nutrition: {match.Groups[4].Value}");
            }                
            
        }
    }
}
