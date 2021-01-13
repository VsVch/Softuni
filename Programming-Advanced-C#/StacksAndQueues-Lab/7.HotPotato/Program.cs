using System;
using System.Collections.Generic;

namespace _7.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine()
                                   .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int cycle = int.Parse(Console.ReadLine());
;
            Queue<string> hotPotato = new Queue<string>(kids);

            int counter = 0;

            string kid = string.Empty;

            while (hotPotato.Count > 1)
            {
                counter++;
                kid = hotPotato.Peek();
                hotPotato.Dequeue();

                if (cycle == counter)
                {
                    counter = 0;
                    Console.WriteLine($"Removed {kid}");
                    
                }
                else
                {
                    hotPotato.Enqueue(kid);
                }
            }
            Console.WriteLine($"Last is {hotPotato.Dequeue()}");
        }
    }
}
