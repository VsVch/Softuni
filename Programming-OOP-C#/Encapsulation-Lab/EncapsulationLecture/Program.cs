using System;
using InternalModifierDemo;

namespace EncapsulationLecture
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Kitchen kitchen = new Kitchen();

            if (kitchen.MeatballsLeft)
            {
                kitchen.OrderMeatball();
            }

        }
    }
}
