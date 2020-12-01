using System;
using System.Linq;

namespace _1.WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] separatingStrings = { ","," " };

            string[] arr = input
                .Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries);                                
            
            string ticket = string.Empty;

            bool IsValidLeftSide = false;

            bool IsValidRightSide = false;            

            foreach (string item in arr)
             {
                if (item.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                ticket = item;

                int leftCounter = 0;

                int rightCounter = 0;

                char symbol = ' ';

                int halfTicket = ticket.Length / 2;               

                for (int i = (ticket.Length / 2) - 1; i >= 0; i--) // '@', '#', '$' and '^'. 
                {
                    if (ticket[i] == '@' || ticket[i] == '#' 
                     || ticket[i] == '$' || ticket[i] == '^')
                    {
                        symbol = ticket[i];
                        leftCounter++;
                                              
                        if (leftCounter >= 6 && leftCounter <= 10)
                        {
                            IsValidLeftSide = true;                            
                        }
                    }
                }
                for (int i  = ticket.Length / 2; i  < ticket.Length; i ++)
                {
                    if (ticket[i] == '@' || ticket[i] == '#'
                     || ticket[i] == '$' || ticket[i] == '^')
                    {
                        rightCounter++;
                        if (rightCounter >= 6 && rightCounter <= 10)
                        {
                            IsValidRightSide = true;                            
                        }
                    }
                }
                if (IsValidLeftSide == true && IsValidRightSide == true)
                {
                    if (leftCounter == 10 && rightCounter == 10)
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - {rightCounter}{symbol} Jackpot!");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - {rightCounter}{symbol}");
                    }
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }

                IsValidLeftSide = false;

                IsValidRightSide = false;
            }
           
           
        }
    }
}
