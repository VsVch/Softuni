using System;

namespace _02.Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];
            int samRow = 0;
            int samCol = 0;
            int nicoladzeRow = 0;
            int nicoladzeCol = 0;

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine().Trim();
                matrix[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col];

                    if (matrix[row][col] == 'S')
                    {
                        samRow = row;
                        samCol = col;
                    }
                    if (matrix[row][col] == 'N')
                    {
                        nicoladzeRow = row;
                        nicoladzeCol = col;
                    }
                }
            }

            bool isSamSucceed = false;
            bool isSamDead = false;
            int curRow = samRow;
            int curCol = samCol;

            while (true)       
            {               
                string command = Console.ReadLine(); 

                for (int i = 0; i < command.Length; i++)
                {
                    if (isSamSucceed == true || isSamDead == true)
                    {
                        break;
                    }

                    char currCommand = command[i]; // chek for enemy

                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < matrix[row].Length; col++)
                        {

                            if (matrix[row][col] == 'b')
                            {
                                matrix[row][col] = '.';
                                col++;
                                bool isValidmove = MoveRight(row, col, n, matrix);

                                if (!isValidmove)
                                {
                                    col--;
                                    matrix[row][col] = 'd';
                                }
                                else
                                {
                                    matrix[row][col] = 'b';
                                }

                            }
                            if (matrix[row][col] == 'd')
                            {
                                matrix[row][col] = '.';
                                col--;
                                bool isValidmove = MoveLift(row, col, n, matrix);

                                if (!isValidmove)
                                {
                                    col++;
                                    matrix[row][col] = 'b';
                                }
                                else
                                {
                                    matrix[row][col] = 'd';
                                }
                            }
                        }
                    }

                    for (int col = 0; col < curCol; col++)
                    {
                        if (matrix[curRow][col] == 'b')
                        {
                            isSamDead = true;
                            matrix[curRow][curCol] = 'X';
                            break;
                        }
                    }

                    for (int col = curCol +1; col < matrix[curRow].Length; col++)
                    {
                        if (matrix[curRow][col] == 'd')
                        {
                            isSamDead = true;
                            matrix[curRow][curCol] = 'X';
                            break;
                        }
                    }

                    if (isSamSucceed == true || isSamDead == true)
                    {
                        break;
                    }

                    if (currCommand == 'U')
                    {
                        curRow--;
                    }
                    else if (currCommand == 'D')
                    {
                        curRow++;
                    }
                    else if (currCommand == 'L')
                    {
                        curCol--;
                    }
                    else if (currCommand == 'R')
                    {
                        curCol++;
                    }
                    else if (currCommand == 'W')
                    {

                    }

                    matrix[samRow][samCol] = '.';
                    samRow = curRow;
                    samCol = curCol;            
                    matrix[curRow][curCol] = 'S';

                    for (int col = 0; col < curCol; col++)
                    {                        
                        if (matrix[curRow][col] == 'b')
                        {
                            isSamDead = true;
                            matrix[curRow][curCol] = 'X';
                            break;
                        }
                    }

                    for (int col = curCol +1; col < matrix[curRow].Length; col++)
                    {
                        if (matrix[curRow][col] == 'd')
                        {
                            isSamDead = true;
                            matrix[curRow][curCol] = 'X';
                            break;
                        }
                    }

                    if (nicoladzeRow == curRow)
                    {
                        matrix[nicoladzeRow][nicoladzeCol] = 'X';
                        isSamSucceed = true;
                    }
                    
                }
                if (isSamSucceed == true || isSamDead == true)
                {
                    break;
                }


            }

            if (isSamSucceed == true)
            {
                Console.WriteLine("Nikoladze killed!");
            }
            else if (isSamDead)
            {
                Console.WriteLine($"Sam died at {curRow}, {curCol}");
            }            

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
            static bool Validation(int row, int col, int n, char [][] matrix) 
            {
                return row >= 0 && row < n && col >= 0 && col < matrix[row].Length;
            
            }

            static bool MoveLift (int row, int col, int n, char[][] matrix) 
            {
                bool IsValidCordinates = Validation(row, col, n, matrix);

                return IsValidCordinates;
            }

            static bool MoveRight(int row, int col, int n, char[][] matrix)
            {
                bool IsValidCordinates = Validation(row, col, n, matrix);

                return IsValidCordinates;
            }

        }
    }
}
