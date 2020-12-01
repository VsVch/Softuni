using System;

namespace _02.CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arryOne = Console.ReadLine().Split(" ");
            string[] arryTwo = Console.ReadLine().Split(" ");

            foreach (string elementTwo in arryTwo)
            {
                for (int i = 0; i < arryOne.Length; i++)
                {
                    if (elementTwo == arryOne[i])
                    {
                        Console.Write(elementTwo + " ");
                        break;
                    }
                }
            }
        }
    }
}
