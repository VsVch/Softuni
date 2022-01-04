using System;
using System.Collections.Generic;
using System.Text;

namespace DIFramework.Contracts
{
    public interface IReader
    {
        string ReadKey();

        string ReadLine();
    }
}
