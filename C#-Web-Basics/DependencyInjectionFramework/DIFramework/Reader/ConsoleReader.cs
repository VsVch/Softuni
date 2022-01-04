using DIFramework.Contracts;
using DIFramework.DI.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIFramework.Reader
{
    public class ConsoleReader : IReader
    {
        private ILogger logger;

        [Inject]
        public ConsoleReader(ILogger logger)
        {
            this.logger = logger;
        }
        public string ReadKey()
        {
           logger.Log("Reading key");

            return "";
        }

        public string ReadLine()
        {
            logger.Log("Reading line");

            return "";
        }
    }
}
