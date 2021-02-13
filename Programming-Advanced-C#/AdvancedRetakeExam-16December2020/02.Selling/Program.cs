using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int clientRow = 0;
            int clientCol = 0;          

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowDate = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowDate[col];

                    if (matrix[row,col] == 'S')
                    {
                        clientRow = row;
                        clientCol = col;
                    }                    
                }
            }
            string input = Console.ReadLine();  // "up", "down", "left", "right"
            bool isOnTheBakery = true;
            int moneyCount = 0;
            bool isEnoughtDolars = false;

            while (true)  
            {
                
                int currRow = clientRow;
                int currCol = clientCol;

                if (input == "up")
                {
                    currRow--;                    
                }
                else if (input == "down")
                {
                    currRow++;                   
                }
                else if (input == "left")
                {
                    currCol--;             
                                     
                }
                else if (input == "right")
                {
                    currCol++;                   
                }
                isOnTheBakery = Validation(currRow, currCol, n);

                if (isOnTheBakery == false)
                {
                    matrix[clientRow, clientCol] = '-';
                    break;
                }
                if (char.IsDigit(matrix[currRow, currCol]))
                {
                    string number = (matrix[currRow, currCol]).ToString();
                    moneyCount += int.Parse(number);
                    
                    if (moneyCount >= 50) // for fixt
                    {
                        isEnoughtDolars = true;                                               
                    }
                }
                if (matrix[currRow, currCol] == 'O')
                {
                    matrix[currRow, currCol] = '-';
                    matrix[clientRow, clientCol] = '-';

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {                       
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {                          
                            if (matrix[row, col] == 'O')
                            {
                                currRow = row;
                                currCol = col;
                                matrix[row, col] = 'S';
                                break;
                            }
                            
                        }
                       
                    }                   
                }
                matrix[clientRow, clientCol] = '-';
                matrix[currRow, currCol] = 'S';

                clientRow = currRow;
                clientCol = currCol;

                if (isEnoughtDolars)
                {
                    break;
                }
                //Console.WriteLine(input); // for delete
                input = Console.ReadLine();
            }

            if (!isOnTheBakery)
            {
                
                Console.WriteLine("Bad news, you are out of the bakery.");
            }        
            if (isEnoughtDolars)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {moneyCount}");

            for (int row = 0; row < n; row++)
            {              
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
        public static bool Validation(int row, int col, int n) 
        {
            return row >= 0 && row < n && col >= 0 && col < n;       
        
        }
    }
}
using System;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
