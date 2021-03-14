using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> data;

        private int index;

        public ListyIterator(List<T> data)
        {
            this.data = data;
            this.index = 0;
            
        }

        public ListyIterator(params T[] data)
        {
            this.data = this.data.ToList();
        
        }
        public bool HasNext()
        {
            bool isValidIndex = false;

            if (index < this.data.Count -1)
            {
                isValidIndex = true;
            }

            return isValidIndex;      
        
        }

        public bool Move() 
        {
            bool isValidIndex = false;

            if (index < this.data.Count - 1)
            {
                index++;
                isValidIndex = true;
            }
            return isValidIndex;
        }

        public void Print() 
        {
            if (index >= this.data.Count)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(this.data[index]);     
        
        }
        public void PrintAll(List<T> data) 
        {
                  
                                
        
        }


        public IEnumerator<T> GetEnumerator()
        {

            foreach (T item in this.data)
            {
                yield return item;
            }
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}
