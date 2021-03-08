using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    public class AddCollection : IAddColection
    {
        private List<string> colection;

        public AddCollection()
        {
            colection = new List<string>();
        }
        public IReadOnlyCollection<string> Colection => colection.AsReadOnly();

        public int AddColection(string element)
        {
            colection.Insert(colection.Count, element);

            return colection.Count - 1;
        }
    }
}
