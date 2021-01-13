using System;
using System.Collections.Generic;

namespace _8.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string input;

            int counter = 0;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    string car = string.Empty;

                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }
                        counter++;
                        car = cars.Peek();
                        cars.Dequeue();
                        Console.WriteLine($"{car} passed!");
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
