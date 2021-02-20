using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Iterators
{
    public class Game : IPrintable, IEnumerable
    {
        public void End(bool isOver)
        {
            Console.WriteLine();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            Console.WriteLine();
        }
    }
}
