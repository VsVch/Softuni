using System;

namespace _05.Messages
{
    class Program
    {
        static void Main(string[] args)
        {            
            int numberOfCycles = int.Parse(Console.ReadLine());

            string words = string.Empty;

            for (int i = 1; i <= numberOfCycles; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number == 2)
                {
                    words += "a";
                }
                else if (number == 22)
                {
                    words += "b";
                }
                else if (number == 222)
                {
                    words += "c";
                }
                else if (number == 3)
                {
                    words += "d";
                }
                else if (number == 33)
                {
                    words += "e";
                }
                else if (number == 333)
                {
                    words += "f";
                }
                else if (number == 4)
                {
                    words += "g";
                }
                else if (number == 44)
                {
                    words += "h";
                }
                else if (number == 444)
                {
                    words += "i";
                }
                else if (number == 5)
                {
                    words += "j";
                }
                else if (number == 55)
                {
                    words += "k";
                }
                else if (number == 555)
                {
                    words += "l";
                }
                else if (number == 6)
                {
                    words += "m";
                }
                else if (number == 66)
                {
                    words += "n";
                }
                else if (number == 666)
                {
                    words += "o";
                }
                else if (number == 7)
                {
                    words += "p";
                }
                else if (number == 77)
                {
                    words += "q";
                }
                else if (number == 777)
                {
                    words += "r";
                }
                else if (number == 7777)
                {
                    words += "s";
                }
                else if (number == 8)
                {
                    words += "t";
                }
                else if (number == 88)
                {
                    words += "u";
                }
                else if (number == 888)
                {
                    words += "v";
                }
                else if (number == 9)
                {
                    words += "w";
                }
                else if (number == 99)
                {
                    words += "x";
                }
                else if (number == 999)
                {
                    words += "y";
                }
                else if (number == 9999)
                {
                    words += "z";
                }
                else if (number == 0)
                {
                    words += " ";
                }               
            }
            Console.WriteLine(words);
        }
    }
}
