using System;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string calcolation = Console.ReadLine();
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());

            switch (calcolation) // add, multiply, subtract, divide
            {
                case "add":
                    Add(numberOne, numberTwo);
                    break;
                case "multiply":
                    Multiply(numberOne, numberTwo);
                    break;
                case "subtract":
                    Substract(numberOne, numberTwo);
                    break;
                case "divide":
                    Divide(numberOne, numberTwo);
                    break;
            }

        }
        private static void Multiply(int numOne, int numTwo)
        {
            Console.WriteLine(numOne * numTwo);
        }
        private static void Divide(int numOne, int numTwo)
        {
            Console.WriteLine(numOne / numTwo);
        }
        private static void Add(int numOne, int numTwo) 
        {
            Console.WriteLine(numOne + numTwo);
        }
        private static void Substract(int numOne, int numTwo) 
        {
            Console.WriteLine(numOne - numTwo);
        }

    }
}
