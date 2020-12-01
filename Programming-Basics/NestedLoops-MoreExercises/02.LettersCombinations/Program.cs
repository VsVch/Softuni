using System;
using System.Threading;

namespace _02.LettersCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char input = Convert.ToChar(Console.ReadLine());
            char inputOne = Convert.ToChar(Console.ReadLine());
            char inputMisst = Convert.ToChar(Console.ReadLine());
            int count = 0;
            for (char i = input; i <= inputOne; i++)
            {
                for (char j = input; j <= inputOne; j++)
                {
                    for (char k = input; k <= inputOne; k++)
                    {
                        if (i != inputMisst && j != inputMisst && k != inputMisst )
                        {
                            if (i == inputOne && j == inputOne && k == inputOne)
                            {
                                count++;
                                Console.Write($"{i}{j}{k} {count}");
                                Environment.Exit(0);
                            }
                            count++;
                            Console.Write($"{i}{j}{k} ");
                        }
                        
                    }
                }
            }
            Console.Write(count);
        }
    }
}
