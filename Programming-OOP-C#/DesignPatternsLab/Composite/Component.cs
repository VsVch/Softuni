using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    public class Component : IComponent
    {
        private List<IComponent> children;

        public Component(Position position)
        {
            Position = position;
            children = new List<IComponent>();
        }      
        public Position Position { get; set; }

        public virtual void Draw()
        {
            foreach (var child in children)
            {
                child.Draw();
            }
        }

        public virtual void Move(Position position)
        {
            this.Position.X += position.X;
            this.Position.Y += position.Y;

            foreach (var child in children)
            {
                child.Move(position);
            }
        }

        public void Add(IComponent component)
        {
            children.Add(component);
        }


        public void Remove(IComponent component)
        {
            children.Remove(component);
        }
    }
}
