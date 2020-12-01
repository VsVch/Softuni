using System;
using System.Linq;

namespace _07.EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            int[] arr2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int sumOfNumbers = 0;
            bool isDifferent = false;

            for (int i = 0; i < arr1.Length; i++)
            {
                sumOfNumbers += arr1[i];
                if (arr1[i] != arr2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    isDifferent = true;
                    break;
                }                
                                   
            }
            if (isDifferent == false)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sumOfNumbers}");
            }
            
        }
    }
}
