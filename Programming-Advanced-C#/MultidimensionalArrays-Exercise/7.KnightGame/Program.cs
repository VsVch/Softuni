using System;

namespace _7.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string rowDate = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowDate[col];                    
                }
            }

            int removeKnightsCounter = 0;
            

            
            
            int currentRemoveCountsKnights = 0;
            for (int row = 0; row < n; row++)
            {

                for (int col = 0; col < n; col++)
                {
                    bool isValidSqere = false;                       

                    if (matrix[row, col] == 'K')                       
                    {                           

                        if (row - 2 >= 0 && col - 1 >= 0 && matrix[row - 2, col - 1] == '0')
                        {
                            isValidSqere = true;
                        }
                        if (row - 2 >= 0 && col + 1 >= 0 && col + 1 < n && matrix[row - 2, col + 1] == '0')
                        {
                            isValidSqere = true;
                        }
                        if (row - 1 >= 0 && col - 2 >= 0 && matrix[row - 1, col - 2] == '0')
                        {
                            isValidSqere = true;
                        }
                        if (row - 1 >= 0 && col + 2 >= 0 && col + 2 < n && matrix[row - 1, col + 2] == '0')
                        {
                            isValidSqere = true;
                        }
                        if (row + 1 >= 0 && row + 1 < n && col - 2 >= 0 && matrix[row + 1, col - 2] == '0')
                        {
                            isValidSqere = true;
                        }
                        if (row + 2 >= 0 && row + 2 < n && col - 1 >= 0 && matrix[row + 2, col - 1] == '0')
                        {
                            isValidSqere = true;
                        }
                        if (row + 2 < n && col + 1 < n && matrix[row + 2, col + 1] == '0')
                        {
                            isValidSqere = true;
                        }
                        if (row + 1 < n && col + 2 < n && matrix[row + 1, col + 2] == '0')
                        {
                            isValidSqere = true;
                        }
                    }
                    if (isValidSqere == false && matrix[row, col] == 'K')
                    {
                        matrix[row, col] = '0';
                        removeKnightsCounter++;
                        currentRemoveCountsKnights++;
                    }
                        
                }
            }        

            
            Console.WriteLine(removeKnightsCounter);
        }
        
    }
}
