using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Loggers
{
    public interface ILogger
    {
        void Info(string date, string messege);
        void Error(string date, string messege);
        void Warning(string date, string messege);
        void Critical(string date, string messege);
        void Fatal(string date, string messege);
    }
}
