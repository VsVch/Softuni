using System;
using System.Linq;

namespace _01.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input;


            while ((input = Console.ReadLine()) != "Complete")
            {
                string[] command = input
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string cmdArg = command[0];

                if (cmdArg == "Make")
                {
                    string caseShrift = command[1];

                    if (caseShrift == "Upper")
                    {
                        text = text.ToUpper();
                    }
                    else
                    {
                        text = text.ToLower();
                    }
                    Console.WriteLine(text);
                }
                else if (cmdArg == "GetDomain")
                {
                    int count = int.Parse(command[1]);
                    int strtIndex = text.Length - count;

                    string printLast = text.Substring(strtIndex);

                    Console.WriteLine(printLast);
                }
                else if (cmdArg == "GetUsername")
                {

                    string substring = string.Empty;


                    if (text.Contains('@'))
                    {
                        int counter = 0;

                        for (int i = 0; i < text.Length; i++)
                        {

                            if (text[i] == '@')
                            {
                                break;
                            }
                            counter++;
                        }
                        substring = text.Substring(0, counter);
                        Console.WriteLine(substring);
                    }
                    else
                    {
                        Console.WriteLine($"The email {text} doesn't contain @ symbol.");
                    }

                }
                else if (cmdArg == "Replace")
                {
                    char ch = char.Parse(command[1]);

                    text = text.Replace(ch, '-');                    

                    Console.WriteLine(text);
                }
                else if (cmdArg == "Encrypt")
                {
                    for (int i = 0; i < text.Length; i++)
                    {
                        Console.Write($" {(int)text[i]}");
                    }
                    Console.WriteLine();
                }
                
            }           
        }
    }
}
