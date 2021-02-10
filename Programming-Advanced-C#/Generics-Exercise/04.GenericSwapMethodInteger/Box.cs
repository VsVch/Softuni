using System;
using System.Collections.Generic;
using System.Text;

namespace _04.GenericSwapMethodInteger
{
    public class Box<T>
    {
        public List<T> List { get; set; } = new List<T>();
        public Box(List<T> list)
        {
            List = list;
        }    
             
        //public List<T> MyAdd(T data)
        //{
        //    this.Data = data;
        //    List.Add(data);
        //    return List;
        //}
        public List<T> Swap(List<T> list, int firstElement, int seconElement) 
        {
            T temp = list[firstElement];
            list[firstElement] = list[seconElement];
            list[seconElement] = temp;

            return list;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in this.List)
            {
                stringBuilder.AppendLine($"{item.GetType()}: {item}");
            }

            return stringBuilder.ToString();
        }
    }
}
