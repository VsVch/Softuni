using System;
using System.Linq;

namespace _03.Zig_ZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] firstArry = new string[n];
            string[] secondArry = new string[n];

            for (int i = 0; i < n; i++)
            {
                string[] currentArry = Console.ReadLine()
                                              .Split(" ")
                                              .ToArray();

                string indexZeroElement = currentArry[0];
                string indexOneElement = currentArry[1];

                if (i % 2 == 0)
                {
                    firstArry[i] = indexZeroElement;
                    secondArry[i] = indexOneElement;
                }
                else if (i % 2 == 1)
                {
                    firstArry[i] = indexOneElement;
                    secondArry[i] = indexZeroElement;
                }             
            }
            Console.WriteLine(string.Join(" ", firstArry));
            Console.WriteLine(string.Join(" ", secondArry));
        }
    }
}
