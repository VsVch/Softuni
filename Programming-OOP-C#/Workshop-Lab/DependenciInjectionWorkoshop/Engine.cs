using DependenciInjectionWorkoshop.Common;
using DependenciInjectionWorkoshop.Contracs;
using DependenciInjectionWorkoshop.DI.Atributes;
using DependenciInjectionWorkoshop.GeameObjects;
using DependenciInjectionWorkoshop.Loggers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DependenciInjectionWorkoshop
{
    public class Engine
    {
        private ILogger logger;
        private IReader reader;
        private List<IGameObject> gameObjects;
        private List<IGameObject> enemys;
        private Ball ball;
        private IMover mover;

        //[Inject]
        public Engine(ILogger logger, IReader reader, IMover mover)
        {
            this.mover = mover;
            this.logger = logger;
            this.reader = reader;
            gameObjects = new List<IGameObject>();
            enemys = new List<IGameObject>();
            ball = InjectorSingleton.Istance.Inject<Ball>();
            gameObjects.Add(ball);
            enemys.Add(InjectorSingleton.Istance.Inject<Enemy>());
            
        }

        public void Strat()
        {                     
            
            while (true)
            { 
                foreach (var gameObject in gameObjects)
                {
                    gameObject.Draw();
                    
                }

                foreach (var enemy in enemys)
                {
                    enemy.Draw();
                    mover.Move(enemy, new Position(1, 0));
                }                

                Position position = reader.ReadKey();
                
                mover.Move(ball, position);

                Thread.Sleep(100);
                Console.Clear();
            }
        }

        public void End()
        {
            logger.Log("Game Ended");
        }
    }
}
