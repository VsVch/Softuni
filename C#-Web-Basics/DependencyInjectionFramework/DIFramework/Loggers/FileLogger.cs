using DIFramework.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DIFramework.Loggers
{
    public class FileLogger : ILogger
    {
        private string path;

        public FileLogger(string path)
        {
            this.path = path;
        }
        public void Log(string message)
        {
            using (StreamWriter writer =
                new StreamWriter(path, true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
