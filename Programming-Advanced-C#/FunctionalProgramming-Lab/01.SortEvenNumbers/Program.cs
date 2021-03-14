using System;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(x => x)
                .Where(x => x % 2 == 0)                
                .ToArray();

                      
            foreach (var item in array)
            {
                if (item == array.Last())
                {
                    Console.Write(item);
                }
                else
                {
                    Console.Write(item + ", ");
                }                   
            }

        }
    }
}
