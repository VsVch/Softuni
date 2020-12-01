using System;

namespace _09.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int widht = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int volume = widht * lenght * height;
            string input = Console.ReadLine();

            while (input != "Done")
            {
                int boxes = int.Parse(input);
                volume -= boxes;
                if (volume < 0)
                {

                    Console.WriteLine($"No more free space! You need {volume * -1} Cubic meters more.");
                    Environment.Exit(0);
                }
                input = Console.ReadLine();  
            }
            
            
            Console.WriteLine($"{volume} Cubic meters left.");
        }
    }
}
