using System;

namespace _5.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dimention = Console.ReadLine().Split(" ");
            int n = int.Parse(dimention[0]);
            int m = int.Parse(dimention[1]);

            string snake = Console.ReadLine();
            int snakeCounter = 0;
            char[,] matrix = new char[n, m];
            int row = 0;
            int col = 0;
            string direction = "right";

            for (int i = 0; i < n * m; i++)
            {
                char ch = snake[snakeCounter];
                snakeCounter++;
                if (snakeCounter == snake.Length)
                {
                    snakeCounter = 0;
                }

                matrix[row, col] = ch;

                if (direction == "right")
                {
                    col++;
                }
                if (direction == "left")
                {
                    col--;
                }

                if (col == m && direction == "right")
                {
                    col--;
                    row++;
                    direction = "left";
                }
                if (col == -1 && direction == "left")
                {
                    col++;
                    row++;
                    direction = "right";
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
