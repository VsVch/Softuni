using System;
using System.Linq;

namespace _6.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] rowDate = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowDate[col];
                }
            }

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split();

                string cmdArg = command[0];
                int currRow = int.Parse(command[1]);
                int currCol = int.Parse(command[2]);
                int digit = int.Parse(command[3]);

                if (currRow>= 0 && currRow < n &&
                    currCol >= 0 && currCol < n)
                {
                    if (cmdArg == "Add")
                    {
                        matrix[currRow, currCol] += digit;
                    }
                    else if (cmdArg == "Subtract")
                    {
                        matrix[currRow, currCol] -= digit;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }                
            }
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
