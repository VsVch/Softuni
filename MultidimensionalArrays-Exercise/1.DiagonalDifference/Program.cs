using System;
using System.Linq;

namespace _1.DiagonalDifference
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

            int primaryDiagonal = 0;
            int primaryReverse = 0;
            int m = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    

                    if (row == col)
                    {
                        primaryDiagonal += matrix[row, col];
                    }
                    if (row == m && col == n - 1 - m)

                    {
                       
                        primaryReverse += matrix[row, col];
                        m++;

                    }
                    
                }               
            }
            int result = Math.Abs(primaryDiagonal - primaryReverse);
            Console.WriteLine(result);
        }
    }
}
