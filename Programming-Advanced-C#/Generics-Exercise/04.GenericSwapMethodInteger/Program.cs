using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> boxes = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());                
                boxes.Add(input);
                
            }

            int[] inputNum = Console.ReadLine()
                                 .Split(" ")
                                 .Select(int.Parse)
                                 .ToArray();

            Box<int> box = new Box<int>(boxes);

            int firstNum = inputNum[0];
            int secondNum = inputNum[1];

            box.Swap(boxes,firstNum, secondNum);
            
            Console.WriteLine(box);            
        }
    }
}
