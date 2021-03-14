using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantlity = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine()
                                  .Split(" ");

            Queue<int> orders = new Queue<int>();

            for (int i = 0; i < input.Length; i++)
            {
                orders.Enqueue(int.Parse(input[i]));
            }

            Console.WriteLine(orders.Max());

            int neededFood = foodQuantlity;

            bool isSucceededOrders = true;

            for (int i = 0; i < input.Length; i++)
            {
                int currentOrder = orders.Peek();

                neededFood -= currentOrder;

                if (neededFood >= 0)
                {
                    orders.Dequeue();
                }
                else
                {
                    isSucceededOrders = false;
                    break;
                }
            }
            if (isSucceededOrders)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
        }
    }
}
