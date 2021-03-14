using System;
using System.Collections.Generic;

namespace _1.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<string> reverceString = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {
                reverceString.Push(input[i].ToString());                
            }

            while (reverceString.Count > 0)
            {
                Console.Write(reverceString.Pop());
            }

        }
    }
}
