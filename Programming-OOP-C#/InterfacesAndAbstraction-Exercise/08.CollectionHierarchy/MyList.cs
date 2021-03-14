using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    public class MyList : IAddColection, IRemoveColection
    {
        private List<string> colection;

        public MyList()
        {
            colection = new List<string>();
        }

        public int Count { get; private set; }

        public IReadOnlyCollection<string> Colection => colection.AsReadOnly();

        public int AddColection(string element)
        {
            int index = 0;
            colection.Insert(index, element);
            Count++;

            return index;
        }
        public string RemoveColection()
        {
            string element = colection[0];
            colection.RemoveAt(0);

            return element;
        }
    }
}
