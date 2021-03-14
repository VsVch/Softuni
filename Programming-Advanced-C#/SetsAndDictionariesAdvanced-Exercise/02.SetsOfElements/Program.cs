using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");

            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            HashSet<int> sequenceM = new HashSet<int>();
            HashSet<int> sequenceN = new HashSet<int>();

            int number;

            for (int i = 0; i < n; i++)
            {
                number = int.Parse(Console.ReadLine());
                sequenceN.Add(number);
            }

            for (int i = 0; i < m; i++)
            {
                number = int.Parse(Console.ReadLine());
                sequenceM.Add(number);
            }

            List<int> num = sequenceM.Intersect(sequenceN).ToList();
            
            Console.WriteLine(string.Join(" ", num));
        }        
    }
}
