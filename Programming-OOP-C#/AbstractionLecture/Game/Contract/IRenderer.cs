using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractionLecture.Contract
{
    interface IRenderer
    {
        void WriteLine(string message);

        void Write(string message);

        void WriteAtPosition(string message, Position position);
    }
}
