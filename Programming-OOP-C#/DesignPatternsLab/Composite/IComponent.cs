using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    public interface IComponent
    {
        public void Add(IComponent component);

        public void Remove(IComponent component);

        void Draw();

        void Move(Position position);
    }
}
