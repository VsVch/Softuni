using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceLecture
{
    public class GameObject 
    {
        
        public GameObject(Position startingPosition)
        {
            Position = startingPosition;
        }
        public Position Position { get; set; }

        public virtual void Draw() 
        {
            Console.WriteLine($"Drawing at {Position.X} : {Position.Y}");
        }
    }
}
