using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();

            string input = Console.ReadLine();

            while (input != "Season end")
            {
                string[] tokens = input.Split();
                if (tokens.Length == 5)
                {
                    string playerName = tokens[0];
                    string positionName = tokens[2];
                    int points = int.Parse(tokens[4]);

                    if (!players.Any(x => x.Name == playerName))
                    {
                        Player player = new Player(playerName);
                        Position position = new Position(points, positionName);
                        player.Positions.Add(position);
                        players.Add(player);
                    }
                    else
                    {
                        Player oldPlayer = players.FirstOrDefault(x => x.Name == playerName);
                        Position position = oldPlayer.Positions.FirstOrDefault(x => x.Name == positionName);
                        if (position == null)
                        {
                            Position newPosition = new Position(points, positionName);
                            oldPlayer.Positions.Add(newPosition);
                        }
                        else
                        {
                            if (position.Points < points)
                            {
                                position.Points = points;
                            }
                        }
                    }
                }
                else if (tokens.Length == 3)
                {
                    string firstPlayerName = tokens[0];
                    string secondPlayerName = tokens[2];
                    Player firstPlayer = players.FirstOrDefault(x => x.Name == firstPlayerName);
                    Player secondPayer = players.FirstOrDefault(x => x.Name == secondPlayerName);
                    if (firstPlayer != null && secondPayer != null)
                    {
                        int result = firstPlayer.Duel(secondPayer);
                        if (result == -1)
                        {
                            players.Remove(secondPayer);
                        }
                        else if (result == 1)
                        {
                            players.Remove(firstPlayer);
                        }
                    }
                }

                input = Console.ReadLine();
            }
            foreach (var player in players)
            {
                player.GetSkill();
            }
            foreach (var player in players.OrderByDescending(x => x.Skill).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{player.Name}: {player.Skill} skill");
                foreach (var position in player.Positions.OrderByDescending(x => x.Points).ThenBy(x => x.Name))
                {
                    Console.WriteLine($"- {position.Name} <::> {position.Points}");
                }
            }
        }
    }

    class Position
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public Position()
        {

        }

        //втория конструктор наследява базовия
        //https://www.w3schools.com/cs/cs_inheritance.asp
        //https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/inheritance
        //https://youtu.be/HHDYuPmNMFI
        public Position(int points, string name) : base()
        {
            Name = name;
            Points = points;
        }

    }

    class Player
    {
        public Player(string name)
        {
            Name = name;

            Positions = new List<Position>();
        }


        public string Name { get; set; }

        public List<Position> Positions { get; set; }

        public int Skill { get; set; }
        public int Duel(Player duelPlayer)
        {
            Position position = new Position();

            foreach (var pos in Positions)
            {
                if (duelPlayer.Positions.Any(x => x.Name == pos.Name))
                {
                    position.Name = pos.Name;
                    break;
                }
            }
            if (position.Name == null)
            {
                return 0;
            }
            Position firstPlayerPositon = Positions.FirstOrDefault(x => x.Name == position.Name);
            Position secondPlayerPositon = duelPlayer.Positions.FirstOrDefault(x => x.Name == position.Name);

            if (firstPlayerPositon.Points == secondPlayerPositon.Points)
            {
                return 0;
            }
            else if (firstPlayerPositon.Points > secondPlayerPositon.Points)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        public void GetSkill()
        {
            foreach (var pos in Positions)
            {
                int points = pos.Points;
                Skill += points;
            }
        }
    }
}