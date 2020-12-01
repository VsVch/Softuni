using System;
using System.Linq;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string word = input;

                //string reverceWord = string.Empty;

                //for (int i = input.Length - 1; i >= 0; i--)
                //{
                //    reverceWord += input[i];
                //}

                //Console.WriteLine($"{word} = {reverceWord}");

                string reverceWord = new string(input.Reverse().ToArray());

                Console.WriteLine($"{word} = {reverceWord}");
            }
        }
    }
}
