using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int [n,n];

            for (int row = 0; row < n; row++)
            {
                int [] rowDate = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowDate[col];
                }
            }

            int[] input = Console.ReadLine().Split(new char[] {' ',','}).Select(int.Parse).ToArray();

            for (int i = 0; i < input.Length; i = i + 2)
            {
                int bombRow = input[i];
                int bombCol = input[i + 1];
                int value = matrix[bombRow, bombCol];

                if (value <= 0)
                {
                    continue;
                }

                if (IsValidCorinate(bombRow - 1, bombCol - 1, n))
                {
                    if (matrix[bombRow - 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol - 1] -= value;
                    }                    
                }
                if (IsValidCorinate(bombRow - 1, bombCol, n))
                {
                    if (matrix[bombRow - 1, bombCol] > 0)
                    {
                        matrix[bombRow - 1, bombCol] -= value;
                    }                    
                }
                if (IsValidCorinate(bombRow - 1, bombCol +1, n))
                {
                    if (matrix[bombRow - 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol + 1] -= value;
                    }                    
                }
                if (IsValidCorinate (bombRow, bombCol +1, n))
                {
                    if (matrix[bombRow, bombCol + 1] > 0)
                    {
                        matrix[bombRow, bombCol + 1] -= value;
                    }                    
                }
                if (IsValidCorinate(bombRow +1, bombCol + 1, n))
                {
                    if (matrix[bombRow + 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol + 1] -= value;
                    }                    
                }
                if (IsValidCorinate(bombRow +1, bombCol, n))
                {
                    if (matrix[bombRow + 1, bombCol] > 0)
                    {
                        matrix[bombRow + 1, bombCol] -= value;
                    }                    
                }
                if (IsValidCorinate(bombRow +1, bombCol - 1, n))
                {
                    if (matrix[bombRow + 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol - 1] -= value;
                    }                    
                }
                if (IsValidCorinate(bombRow, bombCol - 1, n))
                {
                    if (matrix[bombRow, bombCol - 1] > 0)
                    {
                        matrix[bombRow, bombCol - 1] -= value;
                    }                    
                }
                matrix[bombRow, bombCol] = 0;
            }

            int counterAliveSells = 0;
            int aliveSellsSum = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    int sell = matrix[row, col];

                    if (sell > 0)
                    {
                        counterAliveSells++;
                        aliveSellsSum += sell;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {counterAliveSells}");

            Console.WriteLine($"Sum: {aliveSellsSum}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }

        }

        private static bool IsValidCorinate(int bombRow, int bombCol, int n)
        {
        return bombRow >= 0 && bombRow < n && bombCol >= 0 && bombCol < n;
        }
    }
}
