using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Core.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
