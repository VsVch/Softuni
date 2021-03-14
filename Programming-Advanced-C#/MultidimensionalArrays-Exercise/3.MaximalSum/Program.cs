using System;
using System.Linq;

namespace _3.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");

            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowDate = Console.ReadLine()
                .Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowDate[col];
                }
            }
            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < rows - 2; row++)
            {

                for (int col = 0; col < cols - 2; col++)
                {

                    int sum = 0;
                    
                    for (int currRow = row; currRow < row + 3 ; currRow++)
                    {
                        for (int currCol = col; currCol < col + 3 ; currCol++)
                        {
                            sum += matrix[currRow, currCol];                      

                        }
                    }
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = col;
                    }

                }
            }
            Console.WriteLine($"Sum = {maxSum}");

            int rowPrint = maxRow + 3;
            int colPrint = maxCol + 3;

            for (int row = maxRow; row < rowPrint; row++)
            {
                for (int col = maxCol; col < colPrint; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
