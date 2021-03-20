using SOLID_Exercise.Appenders;
using SOLID_Exercise.Core.Factories;
using SOLID_Exercise.Core.IO;
using SOLID_Exercise.Enums;
using SOLID_Exercise.Layout;
using SOLID_Exercise.Loggers;
using System;
using System.Collections.Generic;

namespace SOLID_Exercise
{
    public class Program
    {
       
        static void Main(string[] args)
        {
            //ILayout simpleLayout = new SimpleLayout();
            //IAppender consoleAppender = new FileAppender(simpleLayout);
            //ILogger logger = new Logger(consoleAppender);

            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "Eser Pesho successfully registered.");

            //var simpleLayout = new SimpleLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);
            //consoleAppender.ReportLevel = Enums.ReportLevel.Error;

            //var file = new LogFile();
            //var fillAppender = new FileAppender(simpleLayout, file);

            //var logger = new Logger(consoleAppender);

            //logger.Info("3/26/2015 2:08:11 PM", "Everything seems fine");
            //logger.Warning("3/26/2015 2:08:11 PM", "Warning: ping is too hight - disconect imminent");
            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing request");
            //logger.Critical("3/26/2015 2:08:11 PM", "Nop connection string found in App.config");
            //logger.Fatal("3/26/2015 2:08:11 PM", "mscorlib.dll does not respond");

            //Dictionary<string, ILayout> layoutByType = 
            //    new Dictionary<string, ILayout> 
            //    {
            //        {nameof(SimpleLayout), new SimpleLayout() },
            //        {nameof(XmlLayout), new XmlLayout() },
            //        {nameof(JsonLayout), new JsonLayout() },
            //    };

            IAppenderFactory appenderFactory = new AppenderFactory();
            ILayoutFactory layoutFactory = new LayoutFactory();
            IReader reader = new FileReader();
            IEngine engine = new Engine(appenderFactory, layoutFactory, reader);

            engine.Run();
           
        }       
    }
}
