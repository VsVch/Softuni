using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Commands
{
   public interface ICommand
    {
        decimal Execute(decimal value);

        decimal Unexecute(decimal value);
    }
}
