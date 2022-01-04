using DIFramework.Contracts;
using DIFramework.Loggers;
using DIFramework.Reader;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIFramework.DI.Containers
{
    public class SnakeGameContainer : AbstractContainer
    {
        public override void ConfigureServices()
        {
            this.CreateMapping<ILogger, FileLogger>(()=> new FileLogger("../../../logs.txt"));
            this.CreateMapping<IReader, ConsoleReader>();
        }
    }
}
