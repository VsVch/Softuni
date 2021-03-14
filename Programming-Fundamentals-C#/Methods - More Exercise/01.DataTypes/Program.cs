using System;

namespace _01.DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string variableDeferentTape = Console.ReadLine();
            string input = Console.ReadLine(); // int, double or stringint
            ReadDeferentTapeOfInputs(variableDeferentTape, input);
                       
        }

        private static void ReadDeferentTapeOfInputs(string variableDeferentTape, string input)
        {
            if (variableDeferentTape == "int")
            {
                int intNumber = int.Parse(input);
                intNumber *= 2;
                Console.WriteLine(intNumber);
            }
            else if (variableDeferentTape == "real")
            {
                double doubleNumber = double.Parse(input);
                doubleNumber *= 1.5;
                Console.WriteLine($"{doubleNumber:f2}");
            }
            else if (variableDeferentTape == "string")
            {
                Console.WriteLine($"${input}$");
            }
        }
    }
}
