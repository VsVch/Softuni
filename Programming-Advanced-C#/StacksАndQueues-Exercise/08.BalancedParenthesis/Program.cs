using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); //parentheses

            Stack<char> parantheses = new Stack<char>();

            bool isBalancetParanthes = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {                                      
                    parantheses.Push(')');
                }
                else if(input[i] == '{')
                {
                    parantheses.Push('}');
                }
                else if (input[i] == '[')
                {
                    parantheses.Push(']');
                }
                else
                {
                   char currentParanthes = parantheses.Pop();

                    if (input[i] == currentParanthes)
                    {
                        
                    }
                    else
                    {
                        isBalancetParanthes = false;
                        break;
                    }
                }
            }
            if (isBalancetParanthes)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }


        }
    }
}
