using System;
using System.Collections.Generic;
using System.Text;

namespace BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                bool isBalancet = true;

                Stack<char> openBrackets = new Stack<char>();
               
                for (int j = 0; j < input.Length; j++)
                {
                    char currChar = input[j];

                    if (currChar == '{' || currChar == '[' || currChar == '(')
                    {
                        openBrackets.Push(currChar);
                    }

                    if (currChar == '}' || currChar == ']' || currChar == ')')
                    {
                        if (openBrackets.Count == 0)
                        {
                            isBalancet = false;
                            break;
                        }
                        char openBracket = openBrackets.Pop();
                        isBalancet = IsEqualBrackets(openBracket, currChar);

                        if (!isBalancet)
                        {
                            isBalancet = false;
                            break;
                        }
                    }                    
                }

                if (openBrackets.Count != 0)
                {
                    isBalancet = false;
                }

                if (isBalancet)
                {
                    Console.WriteLine("YES");
                    sb.AppendLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                    sb.AppendLine("NO");
                }
            }
            //Console.Clear();
            //Console.WriteLine(sb.ToString().TrimEnd());
        }
        private static bool IsEqualBrackets(char first, char second) 
        {
            bool isEqualBrackets = false;

            if (first == '{' && second == '}' ||
                first == '(' && second == ')' ||
                first == '[' && second == ']')
            {
                isEqualBrackets = true;                
            }

            return isEqualBrackets;
        }
    }
}
