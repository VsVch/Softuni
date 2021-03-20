using SOLID_Exercise.Enums;
using SOLID_Exercise.Layout;
using SOLID_Exercise.Loggers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOLID_Exercise.Appenders
{
    public class FileAppender : Appender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string date, ReportLevel reportLevel, string messege)
        {
            if (!this.CanAppend(reportLevel))
            {
                return;
            }

            this.MessegesCount += 1;
            string content = string.Format(this.layout.Template, date, reportLevel, messege) + Environment.NewLine;
            File.AppendAllText("../../../ log.txt", content);

            this.logFile.Write(content);
        }
        public override string ToString()
        {
            return base.ToString() + $", File size: {this.logFile.Size}";
        }
    
    }
}
