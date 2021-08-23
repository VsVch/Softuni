using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SOLID_Exercise.Loggers
{
    class LogFile : ILogFile
    {
        private const string FilePath = "../../../ log.txt";
        public int Size => File.ReadAllText(FilePath)
            .Where(t => Char.IsLetter(t))
            .Sum(t => t);

        public void Write(string content)
        {
            File.AppendAllText(FilePath, content);
        }
    }
}
