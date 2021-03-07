using System;
using System.Collections.Generic;

namespace CustomStack
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings<string> stack = new StackOfStrings<string>();

            stack.AddRange(new List<string> 
            { 
                "Mishi",
                "Lubi",
                "Mimi",
                "Sashi",            
            });

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
