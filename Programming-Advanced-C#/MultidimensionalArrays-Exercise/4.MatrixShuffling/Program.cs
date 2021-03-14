using System;
using System.Linq;

namespace _4.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimention = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int rows = dimention[0];
            int cols = dimention[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] rowDate = Console.ReadLine()
                .Split(" ");

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowDate[col];
                }
            }

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split(" ");

                string cmdArg = command[0];                

                bool isInvalidCommand = true;

                if (command.Length != 5 || cmdArg != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    isInvalidCommand = false;
                    continue;
                }

                int firstRow = int.Parse(command[1]);
                int firstCol = int.Parse(command[2]);
                int secondRow = int.Parse(command[3]);
                int secondCol = int.Parse(command[4]);

                bool firstCordinatValidation = CordinatValidation(firstRow, firstCol, rows, cols);
                bool secondCordinatValidation = CordinatValidation(secondRow, secondCol, rows, cols);

                if (!isInvalidCommand || !firstCordinatValidation || !secondCordinatValidation)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                else
                {
                    string firstValue = matrix[firstRow, firstCol];
                    string secondValue = matrix[secondRow, secondCol];
                    matrix[firstRow, firstCol] = secondValue;
                    matrix[secondRow, secondCol] = firstValue;
                }
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col] + " "); 
                    }
                    Console.WriteLine();
                }
            }            
        }

        private static bool CordinatValidation(int row, int col, int rows, int cols)
        {
            bool isInvalidCordinats = row >= 0 && row < rows && col >= 0 && col < cols;

            return isInvalidCordinats;
        }
    }
}
