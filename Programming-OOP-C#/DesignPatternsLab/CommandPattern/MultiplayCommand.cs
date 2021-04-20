using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public class MultiplayCommand : Command
    {
        public MultiplayCommand(decimal valueToChange)
           : base(valueToChange)
        {
        }

        public override decimal Execute(decimal value)
        {
            return value * ValueToChange;
        }

        public override decimal Unexecute(decimal value)
        {
            return value / ValueToChange;
        }
    }
}
