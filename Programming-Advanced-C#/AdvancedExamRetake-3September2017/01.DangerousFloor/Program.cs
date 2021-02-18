using System;
using System.Linq;

namespace _01.DangerousFloor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 8;

            char[,] matrix = new char[n, n];                       

            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console.ReadLine().Split(',').Select(char.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
            string command;          
            
            while ((command = Console.ReadLine()) != "END")
            {                                                    
                char curPice = command[0];
                int curPiceRow = int.Parse(command[1].ToString());
                int curPiceCol = int.Parse(command[2].ToString());
                int newPiceRow = int.Parse(command[4].ToString());
                int newPiceCol = int.Parse(command[5].ToString());

                bool isValidCurrentPosition = false;
                bool isGoodMove = false;
                bool isValidNewPosition = false;

                if (matrix[curPiceRow, curPiceCol] == curPice)
                {
                    isValidCurrentPosition = Validation(curPiceRow, curPiceCol, n);
                    isValidCurrentPosition = true;

                }
                else
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                    
                }

                isValidNewPosition = Validation(newPiceRow, newPiceCol, n);

                if (!isValidNewPosition)
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                if (curPice == 'K' && isValidCurrentPosition && isValidNewPosition)
                {
                    isGoodMove = KingMovement(curPiceRow, curPiceCol, newPiceRow, newPiceCol);
                }                
                if (curPice == 'R' && isValidCurrentPosition && isValidNewPosition)
                {
                    isGoodMove = RookMove(curPiceRow, curPiceCol, newPiceRow, newPiceCol,n);
                }
                if (curPice == 'B' && isValidCurrentPosition && isValidNewPosition)
                {
                    isGoodMove = BishopMove(curPiceRow, curPiceCol, newPiceRow, newPiceCol, n);
                }
                if (curPice == 'Q' && isValidCurrentPosition && isValidNewPosition)
                {
                    isGoodMove = BishopMove(curPiceRow, curPiceCol, newPiceRow, newPiceCol, n);
                    if (!isGoodMove)
                    {
                        isGoodMove = RookMove(curPiceRow, curPiceCol, newPiceRow, newPiceCol, n);
                    }                    
                }
                if (curPice == 'P' && isValidCurrentPosition && isValidNewPosition)
                {
                    isGoodMove = PawnMove(curPiceRow, curPiceCol, newPiceRow, newPiceCol);
                }
                if (isGoodMove)
                {
                    matrix[curPiceRow, curPiceCol] = 'x';
                    matrix[newPiceRow, newPiceCol] = curPice;
                }
                else
                {
                    Console.WriteLine("Invalid move!");
                }
            }

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {
            //        if (col < n-1)
            //        {
            //            Console.Write(matrix[row, col] + ",");
            //        }
            //        else
            //        {
            //            Console.Write(matrix[row, col]);
            //        }                    
            //    }
            //    Console.WriteLine();
            //}
        }

        private static bool PawnMove(int row, int col, int newPiceRow, int newPiceCol)
        {
            bool isValidMove = false;

            if (row-1 == newPiceRow && col == newPiceCol)
            {
                isValidMove = true;
            }
            //else if (row + 1 == newPiceRow && col == newPiceCol)
            //{
            //    isValidMove = true;
            //}
            //else if (row == newPiceRow && col - 1 == newPiceCol)
            //{
            //    isValidMove = true;
            //}
            //else if (row == newPiceRow && col + 1 == newPiceCol)
            //{
            //    isValidMove = true;
            //}

            return isValidMove;
        }

        private static bool BishopMove(int row, int col, int newPiceRow, int newPiceCol, int n)
        {
            bool isValidMove = false;
            int curPiceRow = row;
            int curPiceCol = col;

            while (curPiceRow > 0 || curPiceCol > 0)
            {
                if (curPiceRow == newPiceRow && curPiceCol == newPiceCol)
                {
                    isValidMove = true;
                    break;
                }
                curPiceRow--;
                curPiceCol--;
            }
            curPiceRow = row;
            curPiceCol = col;

            if (!isValidMove)
            {
                while (curPiceRow > 0 || curPiceCol < n)
                {
                    if (curPiceRow == newPiceRow && curPiceCol == newPiceCol)
                    {
                        isValidMove = true;
                        break;
                    }
                    curPiceRow--;
                    curPiceCol++;
                }
            }
            curPiceRow = row;
            curPiceCol = col;

            if (!isValidMove)
            {
                while (curPiceRow < n || curPiceCol < n)
                {
                    if (curPiceRow == newPiceRow && curPiceCol == newPiceCol)
                    {
                        isValidMove = true;
                        break;
                    }
                    curPiceRow++;
                    curPiceCol++;
                }
            }
            curPiceRow = row;
            curPiceCol = col;

            if (!isValidMove)
            {
                while (curPiceRow < n || curPiceCol > 0)
                {
                    if (curPiceRow == newPiceRow && curPiceCol == newPiceCol)
                    {
                        isValidMove = true;
                        break;
                    }
                    curPiceRow++;
                    curPiceCol--;
                }
            }

            return isValidMove;
        }

        private static bool RookMove(int curPiceRow, int curPiceCol, int newPiceRow, int newPiceCol, int n)
        {

            bool isValidMove = false;            

            for (int row = 0; row < n; row++)
            {
                if (row == newPiceRow && curPiceCol == newPiceCol)
                {
                    isValidMove = true;
                    break;
                }
            }
            if (!isValidMove)
            {
                for (int col = 0; col < n; col++)
                {
                    if (curPiceRow == newPiceRow && col == newPiceCol)
                    {
                        isValidMove = true;
                        break;
                    }
                }
            }
            
            return isValidMove;
        }

        private static bool KingMovement(int row,int col, int newPiceRow,int newPiceCol)
        {
            bool isValidMove = false;           

            if (row - 1 == newPiceRow && col - 1 == newPiceCol)           
            {
                isValidMove = true;
            }
            else if (row - 1 == newPiceRow && col == newPiceCol) 
            {
                isValidMove = true;
            }
            else if (row - 1 == newPiceRow && col + 1 == newPiceCol)
            {
                isValidMove = true;
            }
            else if (row == newPiceRow && col + 1 == newPiceCol) 
            {
                isValidMove = true;
            }
            else if (row + 1 == newPiceRow && col + 1 == newPiceCol) 
            {
                isValidMove = true;
            }
            else if (row + 1 == newPiceRow && col == newPiceCol) 
            {
                isValidMove = true;
            }
            else if (row + 1 == newPiceRow && col - 1 == newPiceCol) 
            {
                isValidMove = true;
            }
            else if (row == newPiceRow && col - 1 == newPiceCol) 
            {
                isValidMove = true;
            }
            return isValidMove;

        }

        private static bool Validation(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
    }
}
