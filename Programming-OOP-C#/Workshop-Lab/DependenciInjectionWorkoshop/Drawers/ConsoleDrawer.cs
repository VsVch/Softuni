using DependenciInjectionWorkoshop.Common;
using DependenciInjectionWorkoshop.Contracs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependenciInjectionWorkoshop.Drawers
{
    public class ConsoleDrawer : IDrawer
    {
        public void DrawAtPosition(Position position, string toDraw)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(toDraw);
        }
    }
}
