using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks =
                new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Queue<int> threads =
                new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int taskTarget = int.Parse(Console.ReadLine());
            int killerThread = 0;

            while (true)
            {
                int thread = threads.Peek();
                int task = tasks.Pop();

                if (taskTarget == task)
                {
                    killerThread = thread;
                    break;
                }
                if (thread < task)
                {
                    tasks.Push(task);
                }
                thread = threads.Dequeue();
            }             
         
            Console.WriteLine($"Thread with value {killerThread} killed task {taskTarget}");
            Console.WriteLine(string.Join(" ", threads));           
        }
    }
}
