using System;
using System.Collections.Generic;

namespace _6.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            Queue<string> names = new Queue<string>();

            while ((input = Console.ReadLine()) != "End")
            {

                if (input == "Paid")
                {
                    while (names.Count > 0)
                    {
                        Console.WriteLine(names.Peek());
                        names.Dequeue();
                    }
                }
                else
                {
                    names.Enqueue(input);
                }          
               
            }
            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
