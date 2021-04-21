using DependenciInjectionWorkoshop.Contracs;
using DependenciInjectionWorkoshop.DI.Containers;
using DependenciInjectionWorkoshop.Drawers;
using DependenciInjectionWorkoshop.Loggers;
using DependenciInjectionWorkoshop.Movers;
using DependenciInjectionWorkoshop.Readers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependenciInjectionWorkoshop.Containers
{
    public class SnakeGameContainer : AbstractContainer
    {
        public override void ConfigureService()
        {
            CreateMapping<ILogger, FileLogger>(() => new FileLogger("../../../logs.txt"));
            //CreateMapping<ILogger, ConsoleLogger>();
            CreateMapping<IReader, ConsoleReader>();
            CreateMapping<IDrawer, ConsoleDrawer>();
            CreateMapping<IMover, SlowMover>();
        }
    }
}
