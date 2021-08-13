using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Complexity
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 50000;
            int[] array = new int[count];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
            bool isThere = false;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < count; i++)
            {
                isThere = LinearFind(array, -5);
            }
           
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            watch.Reset();
            HashSet<int> set = new HashSet<int>(array);
            watch.Start();
            for (int i = 0; i < count; i++)
            {
                isThere = ConstantTimeFind(set, -5);
            }
            
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }
        static bool LinearFind(int [] array, int element) 
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    return true;
                }
            }
            return false;
        }

        static bool ConstantTimeFind(HashSet <int> array, int element)
        {
           
            return array.Contains(element);
        }
    }
}
