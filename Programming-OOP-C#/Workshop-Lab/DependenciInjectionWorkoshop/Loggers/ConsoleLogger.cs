using DependenciInjectionWorkoshop.Contracs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependenciInjectionWorkoshop.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string messege)
        {
            Console.WriteLine(messege);
        }
    }
}
