using CommandPattern.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public abstract class Command : ICommand
    {
        public Command(decimal valueToChange)
        {
            ValueToChange = valueToChange;
        }

        public decimal ValueToChange { get; set; }

        public abstract decimal Execute(decimal value);

        public abstract decimal Unexecute(decimal value);
        
    }
}
