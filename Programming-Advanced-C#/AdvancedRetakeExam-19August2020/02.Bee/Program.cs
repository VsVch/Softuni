using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int beeRow = 0;
            int beeCol = 0;

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }                
            }
            int pollinatedFlwers = 0;
            string command;
            while ((command = Console.ReadLine()) != "End") // "up", "down", "left", "right", "End"
            {
                int curRow = beeRow;
                int curCol = beeCol;

                if (command == "up" || command == "down")
                {
                    curRow = MoveUpDown(curRow, command);
                }
                if (command == "left" || command == "right")
                {
                    curCol = MoveLeftRight(curCol, command);
                }

                bool isValidCordinates = Validation(curRow, curCol, n);

                if (!isValidCordinates) // out of matrix
                {
                    matrix[beeRow, beeCol] = '.';
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[curRow, curCol] == 'O')
                {
                    matrix[curRow, curCol] = '.';

                    string currCommand = command;

                    if (currCommand == "up" || currCommand == "down")
                    {
                        curRow = MoveUpDown(curRow, currCommand);
                    }
                    if (currCommand == "left" || currCommand == "right")
                    {
                        curCol = MoveLeftRight(curCol, currCommand);
                    }

                    isValidCordinates = Validation(curRow, curCol, n);

                }     // out of teretory ???           
                if (matrix[curRow, curCol] == 'f')
                {
                    pollinatedFlwers++;
                }
                
                matrix[beeRow, beeCol] = '.';
                matrix[curRow, curCol] = 'B';
                beeRow = curRow;
                beeCol = curCol;
            }

            if (pollinatedFlwers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlwers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlwers} flowers more");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        public static bool Validation(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;

        }

        public static int MoveUpDown(int row, string command) 
        {            
            int curRow = row;           

            if (command == "up")
            {
                curRow--;
            }
            else if (command == "down")
            {
                curRow++;
            }    
            return curRow;
        }

        public static int MoveLeftRight(int col, string command) 
        {            
            int curCol = col;

            if (command == "left")
            {
                curCol--;
            }
            else if (command == "right")
            {
                curCol++;
            }

            return curCol;

        }
    }
}
