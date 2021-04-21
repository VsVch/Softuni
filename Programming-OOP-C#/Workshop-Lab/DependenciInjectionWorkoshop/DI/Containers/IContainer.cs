using System;
using System.Collections.Generic;
using System.Text;

namespace DependenciInjectionWorkoshop.DI.Containers
{
    public interface IContainer
    {
        void ConfigureService();

        void CreateMapping <TInterfaceType, TImplementationType>();

        void CreateMapping <TInterfaceType, TImplementationType>(Func<object> creationFunc);

        Type GetMapping(Type interfaceType);

        KeyValuePair<Type, Func<object>> GetCustomMapping(Type interfaceType);
       
    }
}
