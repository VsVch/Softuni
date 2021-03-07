using AbstractionLecture.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractionLecture
{
    class Ball : GameObject
    {
        public Ball(Position position, Direction direction, IRenderer renderer)
            : base(position, renderer)
        {           
            this.Direction = direction;
        }
        public Direction Direction  { get; set; }

        public override void Draw()
        {
            Renderer.WriteAtPosition("@", Position);
        }
    }
}
