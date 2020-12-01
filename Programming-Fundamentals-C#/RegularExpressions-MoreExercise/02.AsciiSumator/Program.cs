using System;

namespace _02.AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());

            char end = char.Parse(Console.ReadLine());

            var text = Console.ReadLine();

            int startPoin = start;

            int endPoint = end;

            int totalSum = 0;

            for (int i = 0; i < text.Length; i++)
            {
                int number = (int)text[i];

                if (number > startPoin && number < endPoint)
                {
                    totalSum += number;
                }
            }
            Console.WriteLine(totalSum);
        }
    }
}
