using System;
using System.Linq;

namespace _6.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double [][] juggedMatrix = new double[n][];

            for (int row = 0; row < n; row++)
            {
                double [] rowDate = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();

                juggedMatrix[row] = rowDate;
                
            }

            for (int row = 0; row < juggedMatrix.Length-1; row++)
            {
                if (juggedMatrix[row].Length == juggedMatrix[row +1].Length)
                {
                    juggedMatrix[row] = juggedMatrix[row].Select(x => x * 2).ToArray();
                    juggedMatrix[row + 1] = juggedMatrix[row + 1].Select(x => x * 2).ToArray();

                }
                else
                {
                    juggedMatrix[row] = juggedMatrix[row].Select(x => x / 2).ToArray();
                    juggedMatrix[row + 1] = juggedMatrix[row + 1].Select(x => x / 2).ToArray();
                }
            }

            string input;

            while ((input = Console.ReadLine()) !="End")
            {
                string[] command = input.Split(" "); // {row} {column} {value}" 

                string cmdArg = command[0];
                int inputRow = int.Parse(command[1]);
                int inputCol = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                bool isValid = IsValidIndex(inputRow, inputCol, juggedMatrix);

                if (!isValid)
                {
                    continue;
                }
                else
                {
                    if (cmdArg == "Add")
                    {
                        juggedMatrix[inputRow][inputCol] += value;
                    }
                    else if (cmdArg == "Subtract")
                    {
                        juggedMatrix[inputRow][inputCol] -= value;
                    }
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < juggedMatrix[row].Length; col++)
                {
                    Console.Write(juggedMatrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsValidIndex(int row, int col, double [][] juggetmatrix)
        {
            return row >= 0 && row < juggetmatrix.Length && col >= 0 && col < juggetmatrix[row].Length;
        }
    }
}
