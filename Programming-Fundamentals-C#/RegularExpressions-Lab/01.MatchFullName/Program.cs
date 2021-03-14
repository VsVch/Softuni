using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            //string pattern = @"((?:[1-3]?[0-9])|(?:3[01]))-([A-Z][a-z]{2})-([0-9]{4})";

            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+";
            Regex regex = new Regex(pattern);

            string text = Console.ReadLine();

            var matches = regex.Matches(text);

            Console.WriteLine(string.Join(' ',matches));

        }
    }
}
