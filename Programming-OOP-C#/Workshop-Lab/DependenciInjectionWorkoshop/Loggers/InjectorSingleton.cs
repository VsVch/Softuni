using DependenciInjectionWorkoshop.Containers;
using DependenciInjectionWorkoshop.DI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependenciInjectionWorkoshop.Loggers
{
    public static class InjectorSingleton
    {
        private static Injector instance;

        public static Injector Istance 
        {
            get 
            {
                if (instance == null)
                {
                    SnakeGameContainer container = new SnakeGameContainer();
                    container.ConfigureService();
                    instance = new Injector(container);
                }

                return instance;
            }
        }
    }
}
