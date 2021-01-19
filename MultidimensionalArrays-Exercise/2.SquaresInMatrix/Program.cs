using System;

namespace _2.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] rowDate = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowDate[col];
                }
            }
            int equalSqueres = 0;


            for (int row = 0; row < rows -1; row++)
            {
                
                for (int col = 0; col < cols -1; col++)
                {
                    if (matrix[row,col] == matrix[row, col +1] &&
                        matrix[row,col] == matrix[row +1, col] &&
                        matrix[row, col] == matrix[row +1, col +1])
                    {
                        equalSqueres++;
                    }
                }
            }
            Console.WriteLine(equalSqueres);
        }
    }
}
