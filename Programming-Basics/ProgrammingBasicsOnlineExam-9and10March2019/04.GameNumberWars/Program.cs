using System;
using System.ComponentModel.DataAnnotations;

namespace _04.GameNumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            string player1 = Console.ReadLine();
            string player2 = Console.ReadLine();
            bool sTop = false;
            string winner = "";
            int player1Score = 0;
            int player2Score = 0;
            int player1NumberWar = 0;
            int player2NumberWar = 0;

            while (sTop != true)
            {
                string input = Console.ReadLine();
                if (input == "End of game")
                {
                    Console.WriteLine($"{player1} has {player1Score} points");
                    Console.WriteLine($"{player2} has {player2Score} points");
                    sTop = true;
                    break;
                }
                int player1Card = int.Parse(input);
                int player2Card = int.Parse(Console.ReadLine());
                if (player1Card > player2Card)
                {
                    player1Score += player1Card - player2Card;
                    
                }
                else if (player1Card < player2Card)
                {
                    player2Score += player2Card - player1Card;
                }
                else if (player1Card == player2Card)
                {
                    Console.WriteLine("Number wars!"); 
                    player1Card = int.Parse(Console.ReadLine());
                    player2Card = int.Parse(Console.ReadLine());                  
                    if (player1Card > player2Card)
                    {
                       
                        player1NumberWar = player1Card - player2Card;
                        sTop = true;
                        winner = player1;
                        Console.WriteLine($"{winner} is winner with {player1Score} points");
                        break;

                    }
                    else if (player1Card < player2Card)
                    {
                        player2NumberWar += player2Card - player1Card;
                        sTop = true;
                        winner = player2;
                        Console.WriteLine($"{winner} is winner with {player2Score} points");
                        break;
                    }
                    

                }
            }
            
        }
    }
}
