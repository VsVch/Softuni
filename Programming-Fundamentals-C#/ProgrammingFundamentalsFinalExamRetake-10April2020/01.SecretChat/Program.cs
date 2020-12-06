using System;
using System.Collections.Generic;
using System.Linq;



namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            string stringInput;

            while ((stringInput = Console.ReadLine()) != "Reveal")
            {
                string[] command = stringInput
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries);

                string cmdArg = command[0];

                if (cmdArg == "InsertSpace") // { index}
                {
                    int index = int.Parse(command[1]);
                    input = input.Insert(index, " ");

                    Console.WriteLine(input);
                }
                else if (cmdArg == "Reverse") // {substring}
                {
                    string substring = command[1];
                    string newSubstring = string.Empty;
                   
                                    
                    if (input.Contains(substring))                    
                    {
                        
                        int index = input.IndexOf(substring);

                        input = input.Remove(index, substring.Length);

                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            newSubstring += substring[i];
                            
                        }
                        
                        input = input.Insert(input.Length, newSubstring);

                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine($"error");
                    }
                }
                else if (cmdArg == "ChangeAll") // {substring}   {replacement}
                {
                    string substring = command[1];
                    string replacement = command[2];

                    if (input.Contains(substring))
                    {
                       input = input.Replace(substring, replacement);
                    }
                    

                    Console.WriteLine(input);
                }
            }
            Console.WriteLine($"You have a new text message: {input}");
        }
    }
}
