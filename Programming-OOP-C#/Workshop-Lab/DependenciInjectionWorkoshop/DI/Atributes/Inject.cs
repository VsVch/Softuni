using System;
using System.Collections.Generic;
using System.Text;

namespace DependenciInjectionWorkoshop.DI.Atributes
{
    [AttributeUsage(AttributeTargets.Constructor)]
    public class Inject : Attribute
    {
    }
}
