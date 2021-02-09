using System;

namespace _02.GenericBoxofInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int intigerValue = int.Parse(Console.ReadLine());

                Box<int> box = new Box<int>(intigerValue);

                Console.WriteLine(box.ToString());
            }
        }
    }
}
