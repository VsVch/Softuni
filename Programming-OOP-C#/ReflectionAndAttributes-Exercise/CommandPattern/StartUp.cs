using CommandPattern.Core;
using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //ICommandFactory commandFactory = new CommandFactory();

            //ICommand command = commandFactory.CreateCommand("Hello");

            //Console.WriteLine(command.Execute(new string[] { "Sasho" }));

            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
        }
    }

    
}
