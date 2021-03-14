using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Enumerator
{
    public class StringEnumerator : IEnumerator<string>
    {
        private int index = -1;
        public StringEnumerator(string [] array)
        {
            Array = array;
        }
        public string[] Array { get; set; }
        // public string Current => Array[index];
        public string Current { get { return Array[index]; } }
       
        object IEnumerator.Current => Current;

        public void Dispose()
        {           
        }

        public bool MoveNext()
        {
            index ++;
            if (Array.Length <= index)
            {
                return false;
            }
            return true;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
