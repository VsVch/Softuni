using System;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string output = string.Empty;

            if (input.Length % 2 == 0)
            {
                output = PrintMiddeleCharsOfTheEvenString(input);
            }
            else
            {
                output = PrintMiddeleCharsOfTheOddString(input);  
            }

            Console.WriteLine(output);
        }

        private static string PrintMiddeleCharsOfTheOddString(string input)
        {
            int index = input.Length / 2;
            string chars = input.Substring(index, 1);
            return chars;
        }

        private static string PrintMiddeleCharsOfTheEvenString(string input)
        {
            int index = input.Length / 2;
            string chars = input.Substring(index - 1, 2);
            return chars;
        } 
    }
}
