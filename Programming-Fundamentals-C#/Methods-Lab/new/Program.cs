using System;

namespace _03.Calculations
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

                MaxValueInt(numberOne, numberTwo);
            }
            else if (input == "char")
            {
                char charOne = char.Parse(Console.ReadLine());
                char charTwo = char.Parse(Console.ReadLine());

                MaxValueChar(charOne, charTwo);
            }
            else if (input == "string")
            {
                string stringOne = Console.ReadLine();
                string stringTwo = Console.ReadLine();

                MaxValueString(stringOne, stringTwo);
            }

        }
        static void MaxValueInt(int numberOne, int numberTwo)
        {
            int maxNumber = Math.Max(numberOne, numberTwo);

            Console.WriteLine(maxNumber);
        }
        static void MaxValueChar(char charOne, char charTwo)
        {
            int biggerChar = Math.Max(charOne, charTwo);

            char maxChar = charOne;

            if (charOne < charTwo)
            {
                maxChar = charTwo;
            }
            Console.WriteLine(maxChar);
        }
        static void MaxValueString(string stringOne, string stringTwo)
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
                maxString = stringOne;
            }
            else
            {
                maxString = stringTwo;
            }

            Console.WriteLine(maxString);

        }
    }    
}
