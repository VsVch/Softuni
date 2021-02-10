using System;
using System.Collections.Generic;
using System.Text;

namespace _05.GenericCountMethodString
{
    class Box<T> where T : IComparable
    {       

        public Box(List<T> list)
        {
            this.List = list;
        }

        public List<T> List { get; set; }

        public int CountOfGreaterElements ( T element) 
        {
            int greaterElementsCounter = 0;

            for (int i = 0; i < this.List.Count; i++)
            {
                if (element.CompareTo(List[i]) < 0)
                {
                    greaterElementsCounter++;
                }
            }

            return greaterElementsCounter;
        }
       
    }
}
