using System;
using System.Collections.Generic;

namespace WhereMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] {1, 2, 3, 4, 5 };
            Console.WriteLine(string.Join(" ",WhereMethod(array,IsMegicalNum)));

        }
        static bool IsMegicalNum(int number) 
        {
            if (number == 2)
            {
                return true;
            }
            return false;

        }

        static int[] WhereMethod(int[] array, Func<int, bool> condition)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (condition(array[i]))
                {
                    list.Add(array[i]);
                }
            }

            return list.ToArray();       
        
        }
    }
}
