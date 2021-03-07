using AbstractionLecture.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractionLecture
{
    abstract class GameObject 
    {
        protected IRenderer Renderer { get; set; }

        public Position Position { get; set; }


        public GameObject(Position startingPosition, IRenderer renderer)
        {
            Position = startingPosition;
            this.Renderer = renderer;
        }       

        public abstract void Draw();
        
    }
}
