using System;
using System.Collections.Generic;

namespace _04.ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> productName = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                productName.Add(input);
            }

            productName.Sort();

            for (int i = 0; i < productName.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{productName[i]}");
            }            
        }
    }
}
