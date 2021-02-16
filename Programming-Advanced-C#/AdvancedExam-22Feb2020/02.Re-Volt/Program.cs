using System;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int countOfCommands = int.Parse(Console.ReadLine());

            int pleyerRow = 0;
            int playerCol = 0;

            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'f')
                    {
                        pleyerRow = row;
                        playerCol = col;


                    }
                }
            }
            bool isWinPosition = false;

            for (int i = 0; i < countOfCommands; i++) // "up", "down", "left", "right"  
            {        
                string command = Console.ReadLine();
                int curRow = pleyerRow;
                int curCol = playerCol;                

                if (command == "up")
                {
                    curRow--;
                    curRow = StepUp(command, curRow, curCol, n);
                }
                else if (command == "down")
                {
                    curRow++;
                    curRow = StepDown(command, curRow, curCol, n);

                }
                else if (command == "left")
                {
                    curCol--;
                    curCol = StepLeft(command, curRow, curCol, n);
                }
                else if (command == "right")
                {
                    curCol++;                    
                    curCol = StepRight(command, curRow, curCol, n);
                }
                
                if (matrix[curRow,curCol] == 'B')
                {
                    matrix[pleyerRow, playerCol] = '-';
                    string bonusCommand = command;
                    if (bonusCommand == "up")
                    {
                        curRow--;
                        curRow = StepUp(command, curRow, curCol, n);
                    }
                    else if (bonusCommand == "down")
                    {
                        curRow++;
                        curRow = StepDown(command, curRow, curCol, n);

                    }
                    else if (bonusCommand == "left")
                    {
                        curCol--;
                        curCol = StepLeft(command, curRow, curCol, n);
                    }
                    else if (bonusCommand == "right")
                    {
                        curCol++;
                        curCol = StepRight(command, curRow, curCol, n);
                    }
                }

                if (matrix[curRow, curCol] == 'T')
                {
                    matrix[pleyerRow, playerCol] = '-';
                    string penaltyCommand = command;                    

                    if (penaltyCommand == "up")
                    {
                        curRow++;
                        curRow = StepUp(command, curRow, curCol, n);
                    }
                    else if (penaltyCommand == "down")
                    {
                        curRow--;
                        curRow = StepDown(command, curRow, curCol, n);

                    }
                    else if (penaltyCommand == "left")
                    {
                        curCol++;
                        curCol = StepLeft(command, curRow, curCol, n);
                    }
                    else if (penaltyCommand == "right")
                    {
                        curCol--;
                        curCol = StepRight(command, curRow, curCol, n);
                    }
                }
                if (matrix[curRow, curCol] == 'F')
                {
                    isWinPosition = true;
                    matrix[pleyerRow, playerCol] = '-';
                    matrix[curRow, curCol] = 'f';
                    break;
                }

                matrix[pleyerRow, playerCol] = '-';

                pleyerRow = curRow;
                playerCol = curCol;

                matrix[curRow, curCol] = 'f';

            }
            if (isWinPosition)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
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

        public static int StepUp(string command, int row,int col, int n) 
        {            
            bool isValidCordinates = Validation(row, col, n);
            if (!isValidCordinates)
            {
                row = n - 1;
            }
            return row;
        }
        public static int StepDown(string command, int row, int col, int n)
        {
            bool isValidCordinates = Validation(row, col, n);
            if (!isValidCordinates)
            {
                row = 0;
            }
            return row;
        }
        public static int StepLeft(string command, int row, int col, int n)
        {
            bool isValidCordinates = Validation(row, col, n);
            if (!isValidCordinates)
            {
                col = n-1;
            }
            return col;
        }
        public static int StepRight(string command, int row, int col, int n)
        {
            bool isValidCordinates = Validation(row, col, n);
            if (!isValidCordinates)
            {
                col = 0;
            }
            return col;
        }
    }
}
