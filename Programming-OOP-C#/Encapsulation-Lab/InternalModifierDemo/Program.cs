using System;

namespace InternalModifierDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            InternalClass internalClass = new InternalClass();

            internalClass.InternalProperty = 5;
        }
    }
}
