using DIFramework.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIFramework.Loggers
{
    class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
