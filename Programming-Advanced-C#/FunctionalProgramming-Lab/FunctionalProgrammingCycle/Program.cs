using System;

namespace FunctionalProgrammingCycle
{
    class Program
    {
        static void Main(string[] args)
        {
            Loop(() =>
            {
                Console.WriteLine("Misho, Lubi");
            }, 10);
        }

        public static void Loop(Action work, int n)
        {
            if (n == 0)
            {
                return;
            }
            work();
            Loop(work, n-1);
        }
    }
}
