using DependenciInjectionWorkoshop.Common;
using DependenciInjectionWorkoshop.Contracs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependenciInjectionWorkoshop.GeameObjects
{
    public class Ball : IGameObject
    {
        private IDrawer drawer;
        
        public Ball(IDrawer drawer)
        {
            this.drawer = drawer;
            this.Position = new Position(0, 0);
        }

        public Position Position { get; set; }

        public void Draw()
        {
            drawer.DrawAtPosition(Position, "@");
        }
    }
}
