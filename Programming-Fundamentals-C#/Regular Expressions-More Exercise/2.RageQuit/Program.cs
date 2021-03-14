using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _2.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();

            StringBuilder output = new StringBuilder();

            string cycle = string.Empty;

            string uniqueSymbols = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '1' || input[i] == '2' || input[i] == '3' ||
                    input[i] == '4' || input[i] == '5' || input[i] == '6' ||
                    input[i] == '7' || input[i] == '8' || input[i] == '9' || input[i] == '0')
                {
                    int number = 0;
                    if(i != input.Length -1)
                    {
                        if (input[i + 1] == '1' || input[i + 1] == '2' || input[i + 1] == '3' ||
                        input[i + 1] == '4' || input[i + 1] == '5' || input[i + 1] == '6' ||
                        input[i + 1] == '7' || input[i + 1] == '8' || input[i + 1] == '9' || input[i + 1] == '0')
                        {
                            number = int.Parse(input[i] + input[i + 1].ToString());
                        }
                        else
                        {
                            number = int.Parse(input[i].ToString());
                        }
                    }                    
                    else
                    {
                        number = int.Parse(input[i].ToString());
                    }                 
                    
                    for (int j = 0; j < number; j++)
                    {
                        output.Append(cycle);
                    }
                    cycle = string.Empty;
                }
                else
                {
                    cycle += input[i];

                    if (!uniqueSymbols.Contains(input[i]))
                    {
                        uniqueSymbols += input[i];
                    }
                }
            }
            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Length}");
            Console.WriteLine(output);       
        }
    }
}
