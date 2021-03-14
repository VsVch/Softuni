using System;
using System.Collections.Generic;

namespace _02.RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string newWords = string.Empty;

            //for (int i = 0; i < arr.Length; i++)
            //{

            //    for (int j = 0; j < arr[i].Length; j++)
            //    {
            //        newWords += arr[i];
            //    }
            //}

            foreach (var item in arr)
            {
                for (int j = 0; j < item.Length; j++)
                {
                    newWords += item;
                }
            }

            Console.WriteLine(newWords);
        }
    }
}
