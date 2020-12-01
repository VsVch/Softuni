using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> stringOfDigits = Console.ReadLine()
                                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                 .ToList();

            string text = Console.ReadLine();            

            List<int> numbers = new List<int>();

            List<char> textToPrint = new List<char>();

            string n =string.Empty;

            for (int i = 0; i < stringOfDigits.Count; i++)
            {
                n = stringOfDigits[i];

                int number = 0;

                for (int j = 0; j < n.Length; j++)
                {
                    number += (int)n[j] - 48;              
                }

                numbers.Add(number);            

            }
            for (int i = 0; i < numbers.Count; i++)
            {
                int num = numbers[i] + i;

                for (int j = 0; j < text.Length; j++)
                {
                    num --;
                    
                    if (j == text.Length - 1)
                    {
                        j = 0;
                    }                                    
                    if (num == 0)
                    {
                        Console.Write(text[j]);                        
                        break;                        
                    }
                    
                    
                }
                
            }

            
        }
    }
}
