using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Composer> composers = new List<Composer>();

            string input ;

            for (int i = 0; i < n; i++) // {piece}|{composer}|{key}
            {
                string text = Console.ReadLine();

                string[] array = text
                    .Split("|",StringSplitOptions.RemoveEmptyEntries);

                string piece = array[0];
                string name = array[1];
                string key = array[2];

                Composer newComposer = new Composer 
                {
                    Piece = array[0],
                    Name = name,
                    Key = key,
                };

                composers.Add(newComposer);
            }

            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] command = input
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string cmdArg = command[0];
                string newPeace = command[1];

                Composer piece = composers.FirstOrDefault(p => p.Piece == newPeace);

                if (cmdArg == "Add") // {composer}|{key} 
                {
                    string composer = command[2];
                    string key = command[3];                   
                    
                    if (!composers.Contains(piece))
                    {
                        Composer newComposer = new Composer
                        {
                            Piece = newPeace,
                            Name = composer,
                            Key = key,
                        };

                        composers.Add(newComposer);

                        Console.WriteLine($"{newPeace} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{newPeace} is already in the collection!");
                    }
                    
                    
                }
                else if(cmdArg == "Remove")
                {
                    if (composers.Contains(piece))
                    {
                        composers.Remove(piece);
                        Console.WriteLine($"Successfully removed {newPeace}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {newPeace} does not exist in the collection.");
                    }
                }
                else if (cmdArg == "ChangeKey") // {new key}
                {
                    string key = command[2];

                    if (composers.Contains(piece))
                    {
                        piece.Key = key;

                        Console.WriteLine($"Changed the key of {newPeace} to {key}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {newPeace} does not exist in the collection.");
                    }
                }                
            }
            composers = composers.OrderBy(p => p.Piece).ThenBy(n => n.Name).ToList();

            foreach (var item in composers)
            {
                Console.WriteLine($"{item.Piece} -> Composer: {item.Name}, Key: {item.Key}");
            }            
        }
    }
    class Composer // {piece}|{composer}|{key}
    { 
        public string Piece { get; set;}
        public string Name { get; set;}
        public string Key { get; set;}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Piece}");
            sb.Append($"{Name}");
            sb.Append($"{Key}");
            return sb.ToString().Trim();
        }
    }
}
