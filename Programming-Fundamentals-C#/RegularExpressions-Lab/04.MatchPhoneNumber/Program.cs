using System;
using System.Text.RegularExpressions;

namespace _04.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\+\d+([ |-])[2]{1}\1[2]{3}\1[2][2][2][2]";

            string text = Console.ReadLine();

            var matches = Regex.Matches(text, regex);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }   
    }
}
