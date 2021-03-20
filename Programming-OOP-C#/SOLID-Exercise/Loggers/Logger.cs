using SOLID_Exercise.Appenders;
using SOLID_Exercise.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Loggers
{
    public class Logger : ILogger
    {
        private readonly IAppender [] appenders;

        public Logger(params IAppender [] appender)
        {
            this.appenders = appender;
        }

        public void Info(string date, string messege)
        {
            this.AppendToAppenders(date, ReportLevel.Info, messege);
        }
        public void Warning(string date, string messege)
        {
            this.AppendToAppenders(date, ReportLevel.Warning, messege);
        }

        public void Error(string date, string messege)
        {
            this.AppendToAppenders(date, ReportLevel.Error, messege);
        }       

        public void Critical(string date, string messege)
        {
            this.AppendToAppenders(date, ReportLevel.Critical, messege);
        }
        public void Fatal(string date, string messege)
        {
            this.AppendToAppenders(date, ReportLevel.Fatal, messege);
        }

        private void AppendToAppenders(string date,ReportLevel report ,string messege) 
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(date, report, messege);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var appender in this.appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
