using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {        

            Func<List<int>, int> minNumbers = 
            numbers => 
            {

                int numMin = int.MaxValue;

                foreach (int num in numbers)
                {
                    if (num < numMin)
                    {
                        numMin = num;
                    }
                }
                return numMin;
            
            };

            List<int> list = Console.ReadLine()
                   .Split(" ")
                   //.Select(int.Parse)
                   //.Select(x => int.Parse(x))
                   .Select(Parser)
                   .ToList();
            // int newNumber = list.Min();

            int minNumber = minNumbers(list);
            Console.WriteLine(minNumber);

        }
        static int Parser(string num) 
        {
            return int.Parse(num);
        
        }
    }
}
