using System;
using System.Linq;

namespace _2.SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                                 .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowDate = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowDate[col];
                }
            }

            for (int col = 0; col < cols; col++)
            {
                int rowSum = 0;

                for (int row = 0; row < rows; row++)
                {
                    rowSum += matrix[row, col];
                }
                Console.WriteLine(rowSum);
            }

        }
    }
}
