using System;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimention = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int n = dimention[0];
            int m = dimention[1];

            int[,] matrix = new int[n, m];

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    
                }
            }

            string input;

            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int []flowerCordinat = input.Split(" ").Select(int.Parse).ToArray();
                int flowerRow = flowerCordinat[0];
                int flowerCol = flowerCordinat[1];

                bool isValidCordinates = Validation(flowerRow, flowerCol, n, m);

                if (!isValidCordinates)
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    matrix[flowerRow, flowerCol] = 1;

                    int currRow = flowerRow;
                    int currCol = flowerCol;

                    while (currRow > 0) // up
                    {
                        currRow--;
                        matrix[currRow, currCol]++;
                    }

                    currRow = flowerRow;
                    
                    while (currRow  < n-1) // down
                    {
                        currRow++;
                        matrix[currRow, currCol]++;
                    }
                    currRow = flowerRow;

                    while (currCol > 0)
                    {
                        currCol--;
                        matrix[currRow, currCol]++;
                    }

                    currCol = flowerCol;

                    while (currCol < m -1)
                    {
                        currCol++;
                        matrix[currRow, currCol]++;
                    }
                    currCol = flowerCol;
                }

            }

            for (int row = 0;  row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }

        }
        public static bool Validation(int row, int col, int n, int m)
        {
            return row >= 0 && row < n && col >= 0 && col < m;   
        
        }
    }
}
