using System;
using System.Linq;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ");

            var stringOne = input[0];
            var stringTwo = input[1];

            string longerString = stringOne;
            string shorterString = stringTwo;

            if (stringOne.Length < stringTwo.Length)
            {
                longerString = stringTwo;
                shorterString = stringOne;
            }

            int tottalSum = IsSumNumbers(longerString, shorterString);

            Console.WriteLine(tottalSum);                
            
        }
        static private int IsSumNumbers(string longerString, string shoterString) 
        {
            int sumChars = 0;

            for (int i = 0; i < shoterString.Length; i++)
            {
                sumChars += shoterString[i] * longerString[i];

                if (i == shoterString.Length - 1)
                {
                    for (int j = shoterString.Length; j < longerString.Length; j++)
                    {
                        sumChars += longerString[j];
                    }
                }

            }
            return sumChars;
        
        }

    }
}
