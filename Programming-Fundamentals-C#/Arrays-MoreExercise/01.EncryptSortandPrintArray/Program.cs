using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int round = int.Parse(Console.ReadLine());

            int[] namesList = new int[round];                

            for (int i = 0; i < round; i++)
            {
                string name = Console.ReadLine();

                char[] arr = name.ToCharArray();

                int count = name.Length;

                int number = 0;

                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] == 'A' || arr[j] == 'a' || arr[j] == 'E' || arr[j] == 'e' || arr[j] == 'I' || arr[j] == 'i' || arr[j] == 'O' || arr[j] == 'o' || arr[j] == 'U' || arr[j] == 'u') // A, E, I, O, & U
                    {
                        number += arr[j] * count;
                    }
                    else
                    {
                        number += arr[j] / count;
                    }

                }
                namesList[i] = number;
            }
            foreach (var item in namesList.OrderBy(x => x))
            {
                Console.WriteLine(item);
            }

            

        }
    }
}
