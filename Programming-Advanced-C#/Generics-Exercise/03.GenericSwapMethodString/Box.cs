using System;
using System.Collections.Generic;
using System.Text;

namespace _03.GenericSwapMethodString
{
    class Box<T>
    {
        public Box(List<T>list)
        {
            this.List = list;
            
        }

        public T Element { get; set; }

        public List<T> List { get; set; } = new List<T>();

        public List<T> MyAdd(List<T> list, T element)
        {

            list.Add(element);
            return list;

        }                        

        public List<T> Swap(List<T> list, int firstElement, int secondElement) 
        {
            T currentElement = list[firstElement];
            list[firstElement] = list[secondElement];
            list[secondElement] = currentElement;
            return list;
        }

        public override string ToString()
        {

            StringBuilder stringBuilder = new StringBuilder();

            foreach (T item in List)
            {
              stringBuilder.AppendLine($"{item.GetType()}: {item}");
            }
            return stringBuilder.ToString();
        }
    }
}
