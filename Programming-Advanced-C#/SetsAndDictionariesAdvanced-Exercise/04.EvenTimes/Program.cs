using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbersCount = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (!numbersCount.ContainsKey(input))
                {
                    numbersCount.Add(input, 0);
                }
                numbersCount[input]++;

               
            }

            numbersCount = numbersCount.OrderByDescending(v => v.Value).ToDictionary(k => k.Key, v=> v.Value);

            int counter = 0;

            foreach (var item in numbersCount)
            {
                counter++;
                Console.WriteLine(item.Key);

                if (counter == 1)
                {
                    break;
                }
            }
        }
    }
}
