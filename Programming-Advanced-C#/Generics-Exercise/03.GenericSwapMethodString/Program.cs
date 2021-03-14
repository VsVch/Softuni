using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> listOfboxes = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string element = Console.ReadLine();

                listOfboxes.Add(element);                
            }

            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int firstElement = tokens[0];
            int secondElement = tokens[1];

            Box<string> box = new Box<string>(listOfboxes);

            box.Swap(listOfboxes,firstElement, secondElement);

            Console.WriteLine(box);
        }
    }
}
