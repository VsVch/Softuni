using System;

namespace SparseArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] firstArray = new string[n];

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                firstArray[i] = input;
            }

            int m = int.Parse(Console.ReadLine());

            string[] secondArray = new string[m];

            for (int i = 0; i < m; i++)
            {
                string expectetValue = Console.ReadLine();
                secondArray[i] = expectetValue;
            }

            int[] numberArray = new int[m];

            for (int i = 0; i < firstArray.Length; i++)
            {
                for (int j = 0; j < secondArray.Length; j++)
                {
                    if (firstArray[i] == secondArray[j])
                    {
                        numberArray[j] += 1;                       
                    }                    
                }                
            }

            foreach (var number in numberArray)
            {
                Console.WriteLine(number);
            }
        }
    }
}
