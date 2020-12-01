using System;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(?<day>(?:[0-3][0-9])|(?:3[01]))([\.\-\/])(?<month>[A-Z][a-z]{2})\1(?<year>[0-9]{4})";

            string datesString = Console.ReadLine();
                      
            var dates = Regex.Matches(datesString, regex);

            foreach (Match date in dates)
            {
                var day = date.Groups["day"].Value;
                var mounth = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {mounth}, Year: {year}");
            }

        }
    }
}
