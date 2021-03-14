using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClose
{
    public class SelectionSort : ISortingStrategy
    {
        public List<int> Sort(List<int> list) 
        {
            Console.WriteLine("Selection sort sux 0(n^2)");

            return list;
        }
    }
}
