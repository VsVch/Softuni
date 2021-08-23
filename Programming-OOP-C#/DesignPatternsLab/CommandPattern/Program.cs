using CommandPattern.Commands;
using System;

namespace CommandPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            User user = new User(new Calculator());

            while (true)
            {
                Console.WriteLine("Enter operation: ");
                string[] split = Console.ReadLine().Split();

                if (split[0].Contains("undo"))
                {
                    int undoLevels = int.Parse(split[1]);
                    user.Calculator.Undo(undoLevels);
                }
                else
                {
                    char sign = split[0][0];
                    decimal value = decimal.Parse(split[1]);

                    user.Calculate(sign, value);                   
                }

                Console.WriteLine($" New value is: {user.Calculator.Value}");

            }
        }
    }
}
