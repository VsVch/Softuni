using DependenciInjectionWorkoshop.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependenciInjectionWorkoshop.Contracs
{
    public interface IMover
    {
        void Move(IGameObject gameObject, Position position);
    }
}
