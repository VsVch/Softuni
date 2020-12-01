using System;
using System.Text;

namespace _07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int numbersRepead = int.Parse(Console.ReadLine());

            ReapidInput(input, numbersRepead);
        }

        private static void ReapidInput(string input, int numbersRepead)
        {
            StringBuilder stringInput = new StringBuilder();

            for (int i = 0; i < numbersRepead; i++)
            {
                stringInput.Append(input);
            }
            Console.WriteLine(stringInput);
        }
    }
}
