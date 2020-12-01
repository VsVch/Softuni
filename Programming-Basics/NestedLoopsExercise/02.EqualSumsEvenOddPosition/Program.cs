using System;

namespace _02.EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            for (int i = start; i <= end; i++)
            {
                int evenSum = 0;
                int oddnSum = 0;
                int curNum= i;
                int count = 0;
                while (curNum != 0)
                {
                    int digit = curNum % 10;
                    if (count % 2 ==0)
                    {
                        evenSum += digit;
                    }
                    else
                    {
                        oddnSum += digit;
                    }
                    curNum = curNum / 10;
                    count++;
                }
                if (evenSum == oddnSum)
                {
                    Console.Write(i + " ");
                }
                
            }
            
        }
    }
}
