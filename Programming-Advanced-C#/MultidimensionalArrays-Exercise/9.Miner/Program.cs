using System;
using System.Linq;

namespace _9.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            char[,] matrix = new char[n,n];

            int minerRow = 0;
            int minerCol = 0;
            int coalCounter = 0;
            int endRow = 0;
            int endCol = 0;

            for (int row = 0; row < n; row++)
            {
                char[] rowDate = Console.ReadLine().Split(" ").Select(char.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowDate[col];

                    if (matrix[row, col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }

                    if (matrix[row, col] == 'c')
                    {
                        coalCounter++;
                    }
                    if (matrix[row, col] == 'e')
                    {
                        endRow = 0;
                        endCol = 0;
                    }
                }
            }
            bool isGameEnd = false;
            for (int i = 0; i < commands.Length; i++)
            {
                string currCommand = commands[i]; // left, right, up and down

                int currMinerRow = minerRow;
                int currMinerCol = minerCol;

                if (currCommand == "right") 
                {
                    currMinerCol++;
                }
                if (currCommand == "left")
                {
                    currMinerCol--;
                }
                if (currCommand == "up")
                {
                    currMinerRow--;
                }
                if (currCommand == "down")
                {
                    currMinerRow++;
                }

                if (currCommand == "right" && !IsValidCordinats(currMinerRow, currMinerCol, n))
                {
                    currMinerCol--;
                }
                else if (currCommand == "left" && !IsValidCordinats(currMinerRow, currMinerCol, n) )
                {
                    currMinerCol++;
                }
                else if (currCommand == "up" && !IsValidCordinats(currMinerRow, currMinerCol, n))
                {
                    currMinerRow++;
                }
                else if (currCommand == "down" && !IsValidCordinats(currMinerRow, currMinerCol, n))
                {
                    currMinerRow--;
                }

                if (matrix[currMinerRow, currMinerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({ currMinerRow}, {currMinerCol})");
                    break;
                }
                if (matrix[currMinerRow,currMinerCol] == 'c')
                {
                    coalCounter--;
                    matrix[currMinerRow, currMinerCol] = '*';
                    if (coalCounter == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({currMinerRow}, {currMinerCol})");
                        break;
                    }
                }

                matrix[currMinerRow, currMinerCol] = '*';

                minerRow = currMinerRow;
                minerCol = currMinerCol;

                if (i == commands.Length - 1)
                {
                    isGameEnd = true;
                }
            }

            if (isGameEnd)
            {
                Console.WriteLine($"{coalCounter} coals left. ({minerRow}, {minerCol})");
            }
        }            

        private static bool IsValidCordinats(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
    }
}
