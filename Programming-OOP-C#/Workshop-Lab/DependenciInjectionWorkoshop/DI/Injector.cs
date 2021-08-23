using DependenciInjectionWorkoshop.DI.Atributes;
using DependenciInjectionWorkoshop.DI.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DependenciInjectionWorkoshop.DI
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
                //throw new ArgumentException
                //    ("The class has no constructor annoted whit the [Inject] attribute");
            }

            return CreateConstructorInjector<TClass>();
        }
               

        private TClass CreateConstructorInjector<TClass>() 
        {
            ConstructorInfo[] constuctors = typeof(TClass).GetConstructors();

            if (constuctors.Length > 1)
            {
                throw new ArgumentException("Only one constructor allowed");
            }

            foreach (ConstructorInfo constructor in constuctors)
            {
                //if (constructor.getcustomattribute(typeof(inject), true) == null)
                //{
                //    continue;
                //}

                ParameterInfo[] constructorParams = constructor.GetParameters();
                object[] constructorParamObjects = new object[constructorParams.Length];
                int i = 0;
                    
                foreach (ParameterInfo paramInfo in constructorParams)
                {
                    Type interfaceType = paramInfo.ParameterType;
                    Type implementationType = container.GetMapping(interfaceType);

                    object implementationInstance;

                    if (implementationType == null)
                    {
                        var implementationPair = container.GetCustomMapping(interfaceType);
                        implementationInstance = implementationPair.Value();
                    }
                    else
                    {
                        MethodInfo injectMethod = typeof(Injector).GetMethod("Inject");
                        injectMethod = injectMethod.MakeGenericMethod(implementationType);

                        implementationInstance = injectMethod.Invoke(this, new object[]
                        { });
                    }
                    
                    constructorParamObjects[i++] = implementationInstance;
                }

                return (TClass)Activator.CreateInstance(typeof(TClass),constructorParamObjects);
            }

            return default;
        }

        private bool HasConstructorInjection<TClass>()
        {
            //return typeof(TClass).GetConstructors()
            //     .Any(c => c.GetCustomAttributes(typeof(Inject), true).Any());

            return typeof(TClass).GetConstructors()
                .Any(c => c.GetParameters().Length != 0);
        }
    }
}
