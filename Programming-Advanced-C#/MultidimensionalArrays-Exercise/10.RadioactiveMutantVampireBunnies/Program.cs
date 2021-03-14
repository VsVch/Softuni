using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dimentions = Console.ReadLine().Split(" ");

            int n = int.Parse(dimentions[0]);
            int m = int.Parse(dimentions[1]);

            char[,] matrix = new char[n, m];

            int playerRow = 0;
            int playerCol = 0;

            List<string> bunnies = new List<string>();

            for (int row = 0; row < n; row++)
            {
                string rowDate = Console.ReadLine();

                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = rowDate[col];

                    if (matrix[row,col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    if (matrix[row, col] == 'B')
                    {
                        string bunny = IsBunny(row, col);
                        bunnies.Add(bunny);
                    }
                }
            }

            string commands = Console.ReadLine(); // ULLL

            int currPlayerRow = playerRow;
            int currPlayerCol = playerCol;
            bool isWinPosition = false;
            bool isLosePosition = false;
            
            for (int i = 0; i < commands.Length; i++) 
            {
                char currCommand = commands[i];

                if (isWinPosition || isLosePosition)
                {
                    break;
                }

                if (currCommand == 'U') // Up
                {
                    currPlayerRow--;
                }
                if (currCommand == 'D') // Down
                {
                    currPlayerCol++;
                }
                if (currCommand == 'R') // Right
                {
                    currPlayerCol++;
                }
                if (currCommand == 'L') // left
                {
                    currPlayerCol--;
                }

                if (currCommand == 'R' && !IsValidCordinates(currPlayerRow, currPlayerCol, n, m)) // player win ??
                {
                    isWinPosition = true;
                    currPlayerCol--;                    
                }
                if (currCommand == 'L' && !IsValidCordinates(currPlayerRow, currPlayerCol, n, m)) // player win ??
                {
                    isWinPosition = true;
                    currPlayerCol++;                    
                }
                if (currCommand == 'U' && !IsValidCordinates(currPlayerRow, currPlayerCol, n, m)) // player win ??
                {
                    isWinPosition = true;
                    currPlayerRow++;                    
                }
                if (currCommand == 'D' && !IsValidCordinates(currPlayerRow, currPlayerCol, n, m)) // player win ??
                {
                    isWinPosition = true;
                    currPlayerRow--;                    
                }                
                matrix[playerRow, playerCol] = '.';
                playerRow = currPlayerRow;
                playerCol = currPlayerCol;

                while (bunnies.Count > 0)
                {
                    string[] bunnyCordinates = bunnies[0].Split(":");                   

                    int bunnyRow = int.Parse(bunnyCordinates[0]);
                    int bunnyCol = int.Parse(bunnyCordinates[1]);

                    bunnies.RemoveAt(0);

                    if (currPlayerRow == bunnyRow && currPlayerCol == bunnyCol)
                    {
                        matrix[bunnyRow, bunnyCol] = 'B';
                        isLosePosition = true;
                    }
                    if (IsValidCordinates(bunnyRow - 1, bunnyCol, n, m))
                    {
                        if (IsPlayerDead(currPlayerRow, currPlayerCol, bunnyRow -1, bunnyCol))
                        {
                            isLosePosition = true;                            
                        }
                        matrix[bunnyRow - 1, bunnyCol] = 'B';
                    }
                    if (IsValidCordinates(bunnyRow + 1, bunnyCol, n, m))
                    {
                        if (IsPlayerDead(currPlayerRow, currPlayerCol, bunnyRow + 1, bunnyCol))
                        {
                            isLosePosition = true;                            
                        }
                        matrix[bunnyRow + 1, bunnyCol] = 'B';
                    }
                    if (IsValidCordinates(bunnyRow, bunnyCol - 1, n, m))
                    {
                        if (IsPlayerDead(currPlayerRow, currPlayerCol, bunnyRow, bunnyCol -1))
                        {
                            isLosePosition = true;                           
                        }
                        matrix[bunnyRow, bunnyCol - 1] = 'B';
                    }
                    if (IsValidCordinates(bunnyRow, bunnyCol + 1, n, m))
                    {
                        if (IsPlayerDead(currPlayerRow, currPlayerCol, bunnyRow, bunnyCol +1))
                        {
                            isLosePosition = true;                            
                        }
                        matrix[bunnyRow, bunnyCol + 1] = 'B';
                    }           
                }  
                
                
                 for (int row = 0; row < n; row++)
                 {
                     for (int col = 0; col < m; col++)
                     {
                         if (matrix[row, col] == 'B')
                         {

                             string bunny = IsBunny(row, col);
                             bunnies.Add(bunny);
                         }

                     }
                 }              
                

            }         

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }

            if (isWinPosition)
            {
                Console.WriteLine($"won: {currPlayerRow} {currPlayerCol}");
            }
            if (isLosePosition)
            {
                Console.WriteLine($"dead: {currPlayerRow} {currPlayerCol}");
            }


        }

        private static bool IsPlayerDead(int rowOne, int colOne, int rowTwo, int colTwo)
        {
            return rowOne == rowTwo && colOne == colTwo;
        }

        private static string IsBunny(int row, int col)
        {
            string bunnyRow = row.ToString();
            string bunnyCol = col.ToString();

            string bunnyCordinates = $"{bunnyRow}:{bunnyCol}";

            return bunnyCordinates;
        }

        private static bool IsValidCordinates(int currPlayerRow, int currPlayerCow, int n, int m)
        {
            return currPlayerRow >= 0 && currPlayerRow < n && currPlayerCow >= 0 && currPlayerCow < m;
        }
        
    }
}
