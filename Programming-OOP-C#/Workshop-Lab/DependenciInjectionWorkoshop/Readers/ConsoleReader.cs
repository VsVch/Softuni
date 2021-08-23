using DependenciInjectionWorkoshop.Common;
using DependenciInjectionWorkoshop.Contracs;
using DependenciInjectionWorkoshop.DI.Atributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependenciInjectionWorkoshop.Readers
{
    public class ConsoleReader : IReader
    {
        private ILogger logger;

        //[Inject]
        public ConsoleReader(ILogger logger)
        {
            this.logger = logger;

        }

        public Position ReadKey()
        {
            Position position = new Position(0 , 0);

            ConsoleKeyInfo key = new ConsoleKeyInfo();

            while (!Console.KeyAvailable && key.Key != ConsoleKey.Escape)
            {
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        return new Position(0, -1);

                    case ConsoleKey.DownArrow:
                        return new Position(0, 1);

                    case ConsoleKey.RightArrow:
                        return new Position(1, 0);

                    case ConsoleKey.LeftArrow:
                        return new Position(-1, 0);

                    case ConsoleKey.Escape:
                        break;

                    default:
                        if (Console.CapsLock && Console.NumberLock)
                        {
                            Console.WriteLine(key.KeyChar);
                        }
                        break;

                }
            }           

            return position;
        }

        public string ReadLine()
        {
            logger.Log("Reading line");

            return "";
        }
    }
}
