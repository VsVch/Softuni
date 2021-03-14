using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                                         .Split(" ")
                                         .Select(int.Parse)
                                         .ToList();

            List<int> secondList = Console.ReadLine()
                                          .Split(" ")
                                          .Select(int.Parse)
                                          .ToList();

            int firstNum = 0;
            int secontNum = 0;

            
            if (firstList.Count > secondList.Count)
            {
                for (int i = firstList.Count - 1; i >= 0; i--)
                {
                    firstNum = firstList[i - 1];
                    secontNum = firstList[i];
                    firstList.Remove(firstList[i] );
                    firstList.Remove(firstList[i - 1]);
                    break;
                }                     
            }
            else if (secondList.Count > firstList.Count)
            {
                for (int i = secondList.Count - 1; i >= 0; i--)                
                {
                    firstNum = secondList[i - 1];
                    secontNum = secondList[i];
                    secondList.Remove(secondList[i]);
                    secondList.Remove(secondList[i - 1]);
                    break;
                }                  
            }

            int counter = secondList.Count -1;

            List<int> addList = new List<int>();           

            for (int i = 0; i < firstList.Count; i++)
            {
                addList.Add(firstList[i]);
                
                for (int j = counter; j >= 0; j--)
                {
                    addList.Add(secondList[j]);                    
                    counter--;
                    break;
                }
            }
            if (firstNum > secontNum)
            {
                int temporaryNum = firstNum;
                firstNum = secontNum;
                secontNum = temporaryNum;
            }

            List<int> finaleList = new List<int>();
            foreach (var item in addList)
            {
                if (item > firstNum && item < secontNum)
                {
                    finaleList.Add(item);
                }
            }

            foreach (var item in finaleList.OrderBy(x => x))
            {
                Console.Write($" {item}");
            }
        }
    }
}
