using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDouble
{
    public  class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<double> doubleNumbers = new List<double>();

            for (int i = 0; i < n; i++)
            {
                double number = double.Parse(Console.ReadLine());
                doubleNumbers.Add(number);
            }

            double element = double.Parse(Console.ReadLine());

            Box<double> box = new Box<double>(doubleNumbers);

            int countOfElements = box.CountOfElement(doubleNumbers, element);

            Console.WriteLine(countOfElements);

        }
    }
}
