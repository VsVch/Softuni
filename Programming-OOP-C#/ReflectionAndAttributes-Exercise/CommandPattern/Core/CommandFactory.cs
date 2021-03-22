using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandFactory : ICommandFactory
    {
        private const string CommandSuffix = "Command";
        public ICommand CreateCommand(string commandType)
        {
          Type type = Assembly.GetEntryAssembly()
                .GetTypes()
                //.FirstOrDefault(t => t.Name == commandType)
                //.FirstOrDefault(t => t.Name.StartsWith(commandType))
                //.FirstOrDefault(t => t.Name.Contains(commandType));
                .FirstOrDefault(t => t.Name == $"{commandType}{CommandSuffix}");

            if (type ==  null)
            {
                throw new ArgumentException($"{commandType} is invalid command type");
            }
           ICommand istance = (ICommand)Activator.CreateInstance(type);

           return istance;
        }
    }
}
