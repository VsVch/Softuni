using Composite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern.Components
{
    public class Text : Component
    {
        public Text(Position position, string text)
            : base(position)
        {
            this.TextToDraw = text;
        }

        public string TextToDraw { get; set; }

        public override void Draw()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(TextToDraw);

            base.Draw();
        }
    }
}
