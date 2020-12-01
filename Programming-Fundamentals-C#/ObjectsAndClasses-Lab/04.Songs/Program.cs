using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();                       

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] data = Console.ReadLine().Split("_").ToArray();

                string tipe = data[0];
                string name = data[1];
                string time = data[2];

                Song song = new Song();

                song.TipeList = tipe;
                song.Name = name;
                song.Time = time;

                songs.Add(song);
            }
            string favoriteList = Console.ReadLine();

            if (favoriteList == "all")
            {
                foreach (var song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                List<Song> filteredSongs = songs
                                         .Where(n => n.TipeList == favoriteList)
                                         .ToList();

                foreach (var song in filteredSongs)
                {
                    Console.WriteLine(song.Name);
                }

                //foreach (var song in songs)
                //{
                //    if (song.TipeList == favoriteList)
                //    {
                //        Console.WriteLine(song.Name);
                //    }
                //}
            }

        }
        
    }
    class Song
    {
        public string TipeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }
    }


}
