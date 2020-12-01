using System;

namespace _08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int timesPower = int.Parse(Console.ReadLine());

            NumberPower(number, timesPower);
            
        }

        static void NumberPower(int number, double timesPower)
        {
            double poweredNumber = Math.Pow(number, timesPower);

            Console.WriteLine(poweredNumber);
        }        
    }
}
