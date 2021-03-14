using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    public interface IAddColection
    {
        IReadOnlyCollection<string> Colection { get; }

        int AddColection(string element);
    }
}
