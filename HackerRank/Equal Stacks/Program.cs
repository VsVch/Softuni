using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lenght = Console.ReadLine()                
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Queue<int> stack1 = new Queue<int>(lenght[0]);
            Queue<int> stack2 = new Queue<int>(lenght[1]);
            Queue<int> stack3 = new Queue<int>(lenght[2]);

            for (int i = 1; i <= 3; i++)
            {
                List<int> input = Console.ReadLine()                    
                    .Split(" ")
                    .Select(int.Parse)                    
                    .ToList();

                for (int j = 0; j < input.Count; j++)
                {
                    if (i == 1)
                    {
                        stack1.Enqueue(input[j]);
                    }
                    else if (i == 2)
                    {
                        stack2.Enqueue(input[j]);
                    }
                    else if (i == 3)
                    {
                        stack3.Enqueue(input[j]);
                    }
                }            
            }

            while (true)
            {
                int sum1 = stack1.Sum();
                int sum2 = stack2.Sum();
                int sum3 = stack3.Sum();

                if (sum1 == 0 || sum2 == 0 || sum3 == 0)
                {
                    break;
                }

                if (sum1 == sum2 && sum2 == sum3)
                {
                    break;
                }
                else if (sum1 > sum2 && sum1 > sum3)
                {
                    stack1.Dequeue();
                }
                else if (sum2 > sum1 && sum2 > sum3)
                {
                    stack2.Dequeue();
                }
                else if (sum3 > sum1 && sum3 > sum2)
                {
                    stack3.Dequeue();
                }

            }

            if (stack1.Count == 0 || stack2.Sum() == 0 || stack3.Sum() == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack1.Sum());
            }

        }
    }
}
