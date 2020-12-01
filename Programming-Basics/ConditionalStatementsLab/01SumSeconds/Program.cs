using System;

namespace _01SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());
            int totalTime = firstTime + secondTime + thirdTime;
            int minuts = totalTime / 60;
            int seconds = totalTime % 60;
            if (seconds < 10)
            {
                Console.WriteLine($"{minuts}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minuts}:{seconds}");
            }

            // neway
            int totalT = 0;
            totalTime += int.Parse(Console.ReadLine());
            totalTime += int.Parse(Console.ReadLine());
            totalTime += int.Parse(Console.ReadLine());
            int minuts2 = totalT / 60;
            int seconds2 = totalT % 60;
            Console.WriteLine($"{minuts2}:{seconds2:d2}");
            {

            }
        }
    }
}
