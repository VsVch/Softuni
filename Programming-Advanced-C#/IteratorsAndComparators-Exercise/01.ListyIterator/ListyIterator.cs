using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> data;

        private int index;

        public ListyIterator(List<T> data)
        {
            this.data = data;
            this.index = 0;
        }

        public bool Move() 
        {
            bool hastNet = false;

            if (this.HasNext())
            {
                this.index ++;
                hastNet = true;
                
            }
            return hastNet;        
        }
        public bool HasNext() => this.index < data.Count - 1;

        public ListyIterator(params T [] data) 
        {
            this.data = this.data.ToList();
            this.index = 0;
        }

        public void Print()
        {

            if (this.index >= this.data.Count )
            {
                throw new InvalidOperationException("Invalid Operation!");               
            }

            Console.WriteLine(this.data[this.index]);

        }

    }
}
