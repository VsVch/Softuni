using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[A-Za-z]+[.\-_]*\w+@\w+[.\-_]*\w+[.\-_]\w+[.\-_]*\w+";

            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);            
            
            MatchCollection matches =  regex.Matches(input);           

            foreach (Match item in matches)
            {
                Console.WriteLine(item);
            }      
        }
    }
}
