using System;
using System.Collections.Generic;
using System.Text;

namespace _06.GenericCountMethodDouble
{
    public class Box<T> where T : IComparable
    {
        public Box(List<T> list)
        {
            this.List = list;
        }
        public List<T> List { get; set; } = new List<T>();

        public int CountOfElement(List<T> list, T element) 
        {
            int countOfElements = 0;
            
            for (int i = 0; i < list.Count; i++)
            {
                if (element.CompareTo(list[i]) < 0)
                {
                    countOfElements++;
                }
            }
            return countOfElements;        
        }        
    }
}
