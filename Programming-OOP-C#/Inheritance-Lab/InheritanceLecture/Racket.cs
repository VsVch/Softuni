using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceLecture
{
    public class Racket : GameObject
    {
        public Racket(int size, Position position)
            : base(position)
        {
            Size = size;
        }
        public int Size { get; set; }

        public override void Draw()
        {
            for (int i = 0; i < Size; i++)
            {
                Console.SetCursorPosition(Position.X, Position.Y + i);
                Console.WriteLine("|");
            }
            
        }
    }
}
