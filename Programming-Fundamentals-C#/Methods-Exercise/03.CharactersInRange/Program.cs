using System;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            //    char startChar = char.Parse(Console.ReadLine());
            //    char endChar = char.Parse(Console.ReadLine());

            //    PrintCharsBetwinTwoChar(startChar, endChar);           
            //}

            //private static void PrintCharsBetwinTwoChar( char startChar, char endChar)
            //{
            //    if (startChar > endChar)
            //    {
            //        for (int i = endChar + 1; i < startChar; i++)
            //        {
            //            Console.Write((char)i + " ");
            //        }

            //    }
            //    else if (endChar > startChar)
            //    {
            //        for (int i = startChar + 1; i < endChar; i++)
            //        {
            //            Console.Write((char)i + " ");
            //        }
            //    } 

            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            PrintingBetween(firstChar, secondChar);
        }

        private static void PrintingBetween(char firstChar, char secondChar)
        {
            if (firstChar > secondChar)
            {
                char first = firstChar;
                firstChar = secondChar;
                secondChar = first; 
                
                for (int i = firstChar +1; i < secondChar; i++)
                {
                    Console.WriteLine((char)i);
                }



            }
        }
    }
}
