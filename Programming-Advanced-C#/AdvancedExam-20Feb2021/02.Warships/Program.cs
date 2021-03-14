using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            List<string> input = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();

            int firstPlayerShipsCount = 0;
            int secondPlayerShipsCount = 0;
            
           

            int mineRow = 0;
            int mineCol = 0;

            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == '<')
                    {
                        firstPlayerShipsCount++;
                    }
                    if (matrix[row, col] == '>')
                    {
                        secondPlayerShipsCount++;
                    }
                    if (matrix[row, col] == '#')
                    {
                        mineRow = row;
                        mineCol = col;
                    }
                }
            }

            bool firstPlawerWon = false;
            bool secondPlawerWon = false;
            int totalDistroedChips = firstPlayerShipsCount + secondPlayerShipsCount;
            while (input.Count != 0)
            {
                int[] command = input[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int curRow = command[0];
                int curCol = command[1];

                bool isValidordinates = Validation(curRow, curCol, n);

                if (!isValidordinates)
                {
                    input.RemoveAt(0);
                    continue;
                }

                if (matrix[curRow, curCol] == '<')
                {
                    matrix[curRow, curCol] = 'X';
                    firstPlayerShipsCount--;
                }
                if (matrix[curRow, curCol] == '>')
                {
                    matrix[curRow, curCol] = 'X';
                    secondPlayerShipsCount--;
                }
                if (curRow == mineRow && curCol == mineCol)
                {
                    matrix[curRow, curCol] = 'X';

                    bool validMove = Validation(curRow - 1, curCol - 1, n);

                    if (validMove)
                    {
                        if (matrix[curRow -1, curCol -1] == '<')
                        {                           
                            firstPlayerShipsCount--;
                        }
                        else if (matrix[curRow - 1, curCol - 1] == '>')
                        {                           
                            secondPlayerShipsCount--;
                        }
                        matrix[curRow - 1, curCol - 1] = 'X';
                    }

                    validMove = Validation(curRow - 1, curCol, n);

                    if (validMove)
                    {
                        if (matrix[curRow - 1, curCol] == '<')
                        {
                            firstPlayerShipsCount--;
                        }
                        else if (matrix[curRow - 1, curCol] == '>')
                        {
                            secondPlayerShipsCount--;
                        }
                        matrix[curRow - 1, curCol] = 'X';
                    }

                    validMove = Validation(curRow - 1, curCol + 1, n);

                    if (validMove)
                    {
                        if (matrix[curRow - 1, curCol + 1] == '<')
                        {
                            firstPlayerShipsCount--;
                        }
                        else if (matrix[curRow - 1, curCol + 1] == '>')
                        {
                            secondPlayerShipsCount--;
                        }
                        matrix[curRow - 1, curCol + 1] = 'X';
                    }

                    validMove = Validation(curRow, curCol + 1, n);

                    if (validMove)
                    {
                        if (matrix[curRow, curCol + 1] == '<')
                        {
                            firstPlayerShipsCount--;
                        }
                        else if (matrix[curRow, curCol + 1] == '>')
                        {
                            secondPlayerShipsCount--;
                        }
                        matrix[curRow, curCol + 1] = 'X';
                    }

                    validMove = Validation(curRow + 1, curCol + 1, n);

                    if (validMove)
                    {
                        if (matrix[curRow + 1, curCol + 1] == '<')
                        {
                            firstPlayerShipsCount--;
                        }
                        else if (matrix[curRow + 1, curCol + 1] == '>')
                        {
                            secondPlayerShipsCount--;
                        }
                        matrix[curRow + 1, curCol + 1] = 'X';
                    }

                    validMove = Validation(curRow + 1, curCol, n);

                    if (validMove)
                    {
                        if (matrix[curRow + 1, curCol] == '<')
                        {
                            firstPlayerShipsCount--;
                        }
                        else if (matrix[curRow + 1, curCol] == '>')
                        {
                            secondPlayerShipsCount--;
                        }
                        matrix[curRow + 1, curCol] = 'X';
                    }

                    validMove = Validation(curRow + 1, curCol -1, n);

                    if (validMove)
                    {
                        if (matrix[curRow + 1, curCol -1] == '<')
                        {
                            firstPlayerShipsCount--;
                        }
                        else if (matrix[curRow + 1, curCol - 1] == '>')
                        {
                            secondPlayerShipsCount--;
                        }
                        matrix[curRow + 1, curCol - 1] = 'X';
                    }

                    validMove = Validation(curRow, curCol - 1, n);

                    if (validMove)
                    {
                        if (matrix[curRow, curCol - 1] == '<')
                        {
                            firstPlayerShipsCount--;
                        }
                        else if (matrix[curRow, curCol - 1] == '>')
                        {
                            secondPlayerShipsCount--;
                        }
                        matrix[curRow, curCol - 1] = 'X';
                    }


                }

                if (firstPlayerShipsCount == 0)
                {
                    secondPlawerWon = true;
                    break;
                }
                if (secondPlayerShipsCount == 0)
                {
                    firstPlawerWon = true;
                    break;
                }

                input.RemoveAt(0);

            }

            if (firstPlawerWon)
            {
                Console.WriteLine($"Player One has won the game! {totalDistroedChips - firstPlayerShipsCount} ships have been sunk in the battle.");
            }
            if (secondPlawerWon)
            {
                Console.WriteLine($"Player Two has won the game! {totalDistroedChips - secondPlayerShipsCount} ships have been sunk in the battle.");
            }
            if (input.Count == 0)
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShipsCount} ships left. Player Two has {secondPlayerShipsCount} ships left.");
            }

            //for (int row = 0; row < n; row++)
            //{
            //    for (int col = 0; col < n; col++)
            //    {
            //        Console.Write(matrix[row, col] + " ");
            //    }
            //    Console.WriteLine();
            //}
        }
        private static bool Validation(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
    }
}
