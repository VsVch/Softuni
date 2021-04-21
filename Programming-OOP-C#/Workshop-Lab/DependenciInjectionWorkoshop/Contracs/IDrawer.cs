using DependenciInjectionWorkoshop.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependenciInjectionWorkoshop.Contracs
{
    public interface IDrawer
    {
        void DrawAtPosition(Position position, string toDraw);
    }
}
