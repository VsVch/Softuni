using DIFramework.Contracts;
using DIFramework.DI.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIFramework
{
    public class Engine
    {
        private ILogger logger;
        private IReader reader;

        [Inject]
        public Engine(ILogger logger, IReader reader)
        {
            this.logger = logger;
            this.reader = reader;
        }

        public void Start()
        {
            logger.Log("Game Started");
            reader.ReadKey();
            reader.ReadLine();
        }

        public void End()
        {
            logger.Log("Game Ended");
        }
    }
}
