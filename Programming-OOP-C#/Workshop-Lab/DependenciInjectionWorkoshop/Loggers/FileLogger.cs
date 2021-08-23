using DependenciInjectionWorkoshop.Contracs;
using DependenciInjectionWorkoshop.DI.Atributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DependenciInjectionWorkoshop.Loggers
{
    public class FileLogger : ILogger
    {
        private string path;
               
        public FileLogger(string path)
        {
            this.path = path;
        }

        public void Log(string messege)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(messege);
            }
        }
    }
}
