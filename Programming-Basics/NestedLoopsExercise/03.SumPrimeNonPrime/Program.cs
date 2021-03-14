using System;

namespace _03.SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            int sumOfPrime = 0;
            int sumOfOdd = 0;
            
            while (comand != "stop")
            {
                int number = int.Parse(comand);
                int count = 0;
                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                    comand = Console.ReadLine();
                    continue;
                }
                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                    {
                        count++;
                        break;
                    }
                }
                if (number != 1 && count ==0)
                {
                    sumOfPrime += number;
                }
                else
                {
                    sumOfOdd += number;
                }
                comand = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumOfPrime}");   
            Console.WriteLine($"Sum of all non prime numbers is: {sumOfOdd}");   
            

        }
    }
}
