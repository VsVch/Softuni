using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    public class Leaf : IComponent
    {
        public void Add(IComponent component)
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void Move(Position position)
        {
            throw new NotImplementedException();
        }

        public void Remove(IComponent component)
        {
            throw new NotImplementedException();
        }
    }
}
