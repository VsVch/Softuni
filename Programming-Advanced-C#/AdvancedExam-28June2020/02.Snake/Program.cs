using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int snakeRow = 0;
            int snakeCol = 0;            

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }                    
                }
            }
            int foodQuantity = 0;
            bool isVaidCordinats = true;
           
            while (true) // "up", "down", "left", "right"                
            {
                string command = Console.ReadLine();
                int curRow = snakeRow;
                int curCol = snakeCol;

                if (command == "up")
                {
                    curRow--;
                }
                else if (command == "down")
                {
                    curRow++;
                }
                else if (command == "left")
                {
                    curCol--;
                }
                else if (command == "right")
                {
                    curCol++;
                }

                isVaidCordinats = Validation(curRow, curCol, n);

                if (!isVaidCordinats)
                {
                    Console.WriteLine("Game over!");
                    matrix[snakeRow, snakeCol] = '.';                    
                    break;
                }
                if (matrix[curRow, curCol] == '*')
                {
                    foodQuantity++;
                }

                if (matrix[curRow,curCol] == 'B')
                {
                    matrix[curRow, curCol] = '.';

                    for (int row = 0; row < n; row++)
                    {

                        for (int col = 0; col < n; col++)
                        {
                            if (matrix[row,col] == 'B')
                            {
                                curRow = row;
                                curCol = col;
                                matrix[row, col] = '.';
                            }
                        }                        
                    }
                }
                matrix[snakeRow, snakeCol] = '.';

                snakeRow = curRow;
                snakeCol = curCol;

                matrix[snakeRow, snakeCol] = 'S';

                if (foodQuantity >= 10)
                {
                    Console.WriteLine("You won! You fed the snake.");                    
                    break;
                }
            }
            Console.WriteLine($"Food eaten: {foodQuantity}");

            for (int row = 0; row < n; row++)
            {
                
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
        public static bool Validation(int row, int col,int n) 
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
    }
}
