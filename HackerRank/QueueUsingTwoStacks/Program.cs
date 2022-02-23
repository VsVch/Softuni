using System;

namespace Solution // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberQueries = int.Parse(Console.ReadLine());

            var firstStack = new Stack<int>();

            var secondStack = new Stack<int>();

            while (numberQueries != 0)
            {
                var input = Console.ReadLine();

                var inputArray = input.Split(" ");

                var functionNumber = inputArray[0];

                if (functionNumber == "1")
                {
                    var number = int.Parse(inputArray[1]);

                    firstStack.Push(number);
                }
                else if (functionNumber == "2") 
                {
                    CheckEmptyStack(firstStack, secondStack);

                    secondStack.Pop();
                }
                else if (functionNumber == "3")
                {
                    CheckEmptyStack(firstStack, secondStack);

                    Console.WriteLine(secondStack.Peek());
                }

                numberQueries--;
            }
        }

        private static void CheckEmptyStack(Stack<int> firstStack, Stack<int> secondStack)
        {
            if (secondStack.Count == 0)
            {
                while (firstStack.Count != 0)
                {
                    var currNumber = firstStack.Pop();

                    secondStack.Push(currNumber);
                }
            }
        }
    }
}
