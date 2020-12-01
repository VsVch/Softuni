using System;

namespace _06.Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());
            for (int i = 0; i < rooms; i++)
            {
                Console.Write($"L{floors}{i} ");
            }
            Console.WriteLine();
            for (int floor = floors - 1; floor > 0; floor--)
            {
                
                for (int room = 0; room < rooms; room++)
                {
                    if (floor % 2 == 0)
                    {
                        Console.Write($"O{floor}{room} ");
                    }
                    else
                    {
                        Console.Write($"A{floor}{room} ");
                    }
                   



                }
                Console.WriteLine();
            }

        }
    }
}
