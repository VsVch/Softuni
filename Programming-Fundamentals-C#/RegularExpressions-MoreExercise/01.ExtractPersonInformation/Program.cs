using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            StringBuilder name = new StringBuilder();

            StringBuilder age = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == '@')
                    {
                        for (int k = j + 1; k < input.Length; k++)
                        {                         
                            if (input[k] == '|')
                            {
                                break;
                            }                           
                             name.Append(input[k]);
                        }                    
                        
                    }
                }
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == '#')
                    {
                        for (int k = j + 1; k < input.Length; k++)
                        {
                            if (input[k] == '*')
                            {
                                break;
                            }    
                            age.Append(input[k]);
                        }
                    }                    
                }             
               
                Console.WriteLine($"{name} is {age} years old.");

                name.Clear();
                age.Clear();
            }
            
        }
    }
}
