using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> boxes = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string element = Console.ReadLine();

                boxes.Add(element);
            }
            string elementToCompare = Console.ReadLine();

            Box<string> box = new Box<string>(boxes);           

            Console.WriteLine(box.CountOfGreaterElements(elementToCompare));
        }
    }
}
