using System;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            StringBuilder sequence = new StringBuilder();

            for (int i = 0; i < input.Length-1; i++)
            {
                char number = input[i];

                if (number != input [i + 1])
                {
                    sequence.Append(input[i]);                    
                }
                
            }
            var symbol = input[input.Length - 1];
            sequence.Append(symbol);
            Console.WriteLine(sequence);
        }
    }
}
