using System;

namespace AccessModifiers
{
    public class Program
    {
        static void Main(string[] args)
        {
           Base baseObject = new Base();

            Child child = new Child();

            baseObject.BaseMethod();
            child.BaseMethod();
                
        }
    }
}
