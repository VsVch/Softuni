using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> stringOfDigits = Console.ReadLine()
            List<string> stringOfDigits = Console.ReadLine()
            //                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //                                     .ToList();

            //string text = Console.ReadLine();            

            //List<int> numbers = new List<int>();

            //List<char> textToPrint = new List<char>();

            //string n =string.Empty;

            //for (int i = 0; i < stringOfDigits.Count; i++)

            string text = Console.ReadLine();            

            List<int> numbers = new List<int>();

            List<char> textToPrint = new List<char>();

            string n =string.Empty;

            for (int i = 0; i < stringOfDigits.Count; i++)
            //{
            //    n = stringOfDigits[i];

            //    int number = 0;

            //    for (int j = 0; j < n.Length; j++)
            //    {
            //        number += (int)n[j] - 48;              
            //    }

            //    numbers.Add(number);            

            //}
            //for (int i = 0; i < numbers.Count; i++)
            //{
            //    int num = numbers[i] + i;

            //    for (int j = 0; j < text.Length; j++)
            //    {
            //        num --;

            //        if (j == text.Length - 1)
            //        {
            //            j = 0;
            //        }                                    
            //        if (num == 0)
            //        {
            //            Console.Write(text[j]);                        
            //            break;                        
            //        }


            //    }

            //}

            List<string> numbers = Console.ReadLine()
                .Split(" ")                
                .ToList();

            string input = Console.ReadLine();           

            List<int> sumNumbers = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int number = 0;
                string currentNum = string.Empty;

                for (int j = 0; j < numbers[i].Length; j++)
                {
                    currentNum = numbers[i][j].ToString();
                    number += int.Parse(currentNum);
                   
                }
                sumNumbers.Add(number);
            }

            string messege = string.Empty;           

            for (int i = 0; i < sumNumbers.Count; i++)
            {
                
                int currentNum = sumNumbers[i];               

                for (int j = 0; j <= input.Length; j++)
                {
                    
                    if (j  == input.Length )
                    {
                        j = 0;
                    }

                    if (currentNum == 0)
                    {
                        messege += input[j].ToString();
                        input = input.Remove(j, 1);                        
                        break;
                    }

                    currentNum--;
                }
            }
            Console.WriteLine(messege);
        }
    }
}
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
