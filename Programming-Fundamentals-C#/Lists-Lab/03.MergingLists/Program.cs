using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToList();
            List<int> secondList = Console.ReadLine()
                                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToList();
           

            List<int> result = new List<int>();
                       
            for (int i = 0; i < firstList.Count; i++)
            {
                result.Add(firstList[i]);
            
                for (int j = 0; j < secondList.Count; j++)
                {
                    if (i == firstList.Count - 1)
                    {
                        result.Add(secondList[j]);
                       
                    }
                    else
                    {
                        result.Add(secondList[0]);
                        secondList.Remove(secondList[0]);
                        break;
                    }
                               
                }
            }                          
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
