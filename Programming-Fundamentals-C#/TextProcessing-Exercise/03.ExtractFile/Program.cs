using System;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split("\\");

            var neededInput = input[input.Length - 1].Split(".");

            Console.WriteLine($"File name: {neededInput[0]}");
            Console.WriteLine($"File extension: {neededInput[1]}");

            
        }
    }
}
