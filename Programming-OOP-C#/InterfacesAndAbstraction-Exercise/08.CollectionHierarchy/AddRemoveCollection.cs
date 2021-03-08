using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    public class AddRemoveCollection : IAddColection, IRemoveColection
    {
        private List<string> colection;

        public AddRemoveCollection()
        {
            colection = new List<string>();
        }

        public IReadOnlyCollection<string> Colection => colection.AsReadOnly();

        public int AddColection(string element)
        {
            int index = 0;
            colection.Insert(0, element);

            return index;
        }

        public string RemoveColection()
        {
            string element = colection[colection.Count - 1];
            colection.RemoveAt(colection.Count - 1);

            return element;
        }
    }
}
