using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int, int> comperor =
                new EqualityScale<int, int>();

            Console.WriteLine(comperor.AreEqual(6, 6));          

        }
    }
}
