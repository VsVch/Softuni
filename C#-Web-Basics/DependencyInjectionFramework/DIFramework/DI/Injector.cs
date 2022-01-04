using DIFramework.DI.Attributes;
using DIFramework.DI.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DIFramework.DI
{
    public class Injector
    {
        private IContainer container;
        public Injector(IContainer container)
        {
            this.container = container;
        }

        public TClass Inject<TClass>()
        {
            if (!HasConstructorInjection<TClass>())
            {
                return (TClass)Activator.CreateInstance(typeof(TClass));
                //throw new ArgumentException("The class has no constructor annoted with the [Inject] attribute");
            }

            return CreateConstructorInjection<TClass>();
        }      

        private TClass CreateConstructorInjection<TClass>()
        {
            ConstructorInfo[] constructors = typeof(TClass).GetConstructors();
                       
            foreach (var constructor in constructors)
            {
                if (constructor.GetCustomAttribute(typeof(Inject), true) == null)
                {
                    continue;
                }

                ParameterInfo[] constructorParams = constructor.GetParameters();

                object[] constructorParamObjects = new object[constructorParams.Length];
                int i = 0;
                foreach (var paramInfo in constructorParams)
                {

                    var implementationInstance = GetInstance(paramInfo.ParameterType);

                    constructorParamObjects[i++] = implementationInstance;

                }
                return (TClass)Activator.CreateInstance(typeof(TClass), constructorParamObjects);
            }
            return default;
        }

        private object GetInstance(Type type)
        {
            Type interfaceType = type;
            Type implemantationType = container.GetMapping(interfaceType);

            object implementationInstance = null;

            if (implemantationType == null)
            {
                var implementationPair = container.GetCustomMapping(interfaceType);
                implementationInstance = implementationPair.Value();
            }
            else
            {
                implementationInstance = CallGenericMethod(implemantationType);
            }

            return implementationInstance;
        }

        private object CallGenericMethod(Type type) 
        {
            MethodInfo injectMethod = typeof(Injector).GetMethod("Inject");
            injectMethod = injectMethod.MakeGenericMethod(type);

            object implementationInstance = injectMethod.Invoke(this, new object[] { });

            return implementationInstance;
        }
            
        private bool HasConstructorInjection<TClass>()
        {
            return typeof(TClass).GetConstructors()
                .Any(c => c.GetCustomAttributes(typeof(Inject), true).Any());
        }
    }
}
