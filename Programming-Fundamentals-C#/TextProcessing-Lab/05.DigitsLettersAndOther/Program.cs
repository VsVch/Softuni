using System;

namespace _05.DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string digits = string.Empty;

            string letter = string.Empty;

            string symbol = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                
                if (char.IsDigit(input[i]))
                {
                    digits += input[i];
                }
                else if (char.IsLetter(input[i]))
                {
                    letter += input[i];
                }
                else
                {
                    symbol += input[i];
                }                
            }
            Console.WriteLine(digits);
            Console.WriteLine(letter);
            Console.WriteLine(symbol);
        }
    }
}
