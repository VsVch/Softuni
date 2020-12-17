using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int[] array = input
                               .Split(" ")
                               .Select(int.Parse)
                               .ToArray();
            int leftCount = array.Length / 4;
            int rightCount = array.Length;
            int count = 0;


            List<int> collection = new List<int>();

            for (int i = (array.Length / 4) - 1; i >= 0; i--)
            {
                int leftSum = 0;

                
                for (int j = leftCount; j < array.Length / 2; j++)
                {
                    leftSum = array[i] + array[j];
                    collection.Add(leftSum);
                    leftCount++;
                    break;
                }
            }
           
            for (int i = array.Length / 2; i < array.Length; i++)
            {
                int rightSum = 0;
                count++;

                if (array.Length * 3 / 4  == i)
                {
                    break;
                }

                for (int j = rightCount - 1; j >= array.Length / 2; j--)
                {
                    rightSum = array[i] + array[j];
                    collection.Add(rightSum);
                    rightCount--;
                    break;
                }            
            }
            
            Console.Write(string.Join(" ",collection));
            
        }
    }
}
