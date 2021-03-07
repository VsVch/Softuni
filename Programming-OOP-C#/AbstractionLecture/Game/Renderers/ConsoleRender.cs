using AbstractionLecture.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractionLecture.Renderers
{
    public class ConsoleRender : IRenderer
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteAtPosition(string message, Position position)
        {
            Console.SetCursorPosition(position.Y, position.X);
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
