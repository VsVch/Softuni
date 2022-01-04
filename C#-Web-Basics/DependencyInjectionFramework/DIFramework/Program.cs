using DIFramework.Contracts;
using DIFramework.DI;
using DIFramework.DI.Containers;
using DIFramework.Loggers;
using System;

namespace DIFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer container = new SnakeGameContainer();
            container.ConfigureServices();
            Injector injector = new Injector(container);
           
            Engine engine = injector.Inject<Engine>();

            engine.Start();
            engine.End();
        }
    }
}
