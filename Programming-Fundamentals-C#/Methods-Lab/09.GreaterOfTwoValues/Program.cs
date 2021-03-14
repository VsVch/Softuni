
using System;

namespace _09.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input == "int")
            {
                int numberOne = int.Parse(Console.ReadLine());
                int numberTwo = int.Parse(Console.ReadLine());

                int resultInt = MaxValueInt(numberOne, numberTwo);
                Console.WriteLine(resultInt);
            }

            else if (input == "char")
            {
                char charOne = char.Parse(Console.ReadLine());
                char charTwo = char.Parse(Console.ReadLine());

                char resultChar = MaxValueChar(charOne, charTwo);
                Console.WriteLine(resultChar);
            }

            else if (input == "string")
            {
                string stringOne = Console.ReadLine();
                string stringTwo = Console.ReadLine();

                string resultString = MaxValueString(stringOne, stringTwo);
                Console.WriteLine(resultString);
            }

        }
        static int MaxValueInt(int numberOne, int numberTwo)
        {
            if (numberOne > numberTwo)
            {
                return numberOne;
            }
            return numberTwo;
        }
        static char MaxValueChar(char charOne, char charTwo)
        {
            if (charOne < charTwo)
            {
                return charTwo;
            }
            return charOne;
        }
        static string MaxValueString(string stringOne, string stringTwo)
        {
            int stringOneSum = 0;
            int stringTwoSum = 0;
            string maxString = string.Empty;

            for (int i = 0; i < stringOne.Length; i++)
            {
                stringOneSum += i;
            }
            for (int j = 0; j < stringTwo.Length; j++)
            {
                stringTwoSum += j;
            }
            if (stringOneSum > stringTwoSum)
            {
                return stringOne;
            }
            return stringTwo;
        }

    }
}
