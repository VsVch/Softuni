using SOLID_Exercise.Enums;
using SOLID_Exercise.Layout;
using System;

namespace SOLID_Exercise.Appenders
{
    public abstract class Appender :IAppender
    {
        protected ILayout layout;

        public Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        protected int MessegesCount { get; set; }
        public abstract void Append(string date, ReportLevel reportLevel, string messege);

        protected bool CanAppend(ReportLevel reportLevel) 
        {
            return reportLevel >= this.ReportLevel;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.MessegesCount}";
        }
    }
}
