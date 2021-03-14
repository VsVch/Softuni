using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                    .Split(", ",StringSplitOptions.RemoveEmptyEntries);

            Queue<string> songs = new Queue<string>(input);

            string commands = Console.ReadLine();

           
            while (songs.Any())
            {

                if (commands.Contains("Play"))
                {
                    songs.Dequeue();          

                }
                else if (commands.Contains("Add"))
                {
                    string song = commands.Substring(3, commands.Length - 3).Trim();

                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");                       
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                }
                else if (commands.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", songs));
                }             

                commands = Console.ReadLine();

                if (songs.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                }
            }
        }
    }
}
