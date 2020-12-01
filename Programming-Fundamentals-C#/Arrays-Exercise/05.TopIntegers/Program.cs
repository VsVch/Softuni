using System;
using System.Linq;

namespace _05.TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            bool isBigger = true;

            for (int i = 0; i < arr.Length; i++)
            {
                int curentInt = arr[i];

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] >= curentInt)
                    {
                        isBigger = false;
                        break;

                    }
                }
                if (isBigger == true)
                {
                    Console.Write(curentInt + " ");
                }
                isBigger = true;
            }
        }
    }
}
