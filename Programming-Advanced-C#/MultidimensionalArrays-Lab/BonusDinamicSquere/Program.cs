using System;
using System.Linq;

namespace BonusDinamicSquere
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowDate = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowDate[col];
                }
            }

            int maxValue = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < rows - n+1; row++)
            {
                for (int col = 0; col < cols - n + 1; col++)
                {
                    int squereSum = 0;

                    for (int squreRow = row; squreRow < row + n; squreRow++)
                    {
                        for (int squereCol = col; squereCol < col + n; squereCol++)
                        {
                            squereSum += matrix[squreRow, squereCol];

                            
                        }
                    }
                    if (squereSum > maxValue)
                    {
                        maxValue = squereSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
            for (int row = maxRow; row < maxRow + n; row++)
            {
                for (int col = maxCol; col < maxCol+n; col++)
                {
                    Console.Write(matrix[row,col]+ " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxValue);
        }
    }
}
