using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClose
{
    public class QuickSort : ISortingStrategy
    {
        public List<int> Sort(List<int> list)
        {
            Console.WriteLine("QuickSort is vety good  0(n * log(n)");

            return list;
        }
    }
}
