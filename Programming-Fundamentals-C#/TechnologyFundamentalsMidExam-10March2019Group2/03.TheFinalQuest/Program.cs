using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.TheFinalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> colection = Console.ReadLine()                                            
                                            .Split(" ")                                            
                                            .ToList();

            string input;

            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] command = input.Split(" ").ToArray();

                string cmdArg = command[0];

                if (cmdArg == "Sort")
                {
                    colection.Sort();
                    colection.Reverse();
                }
                else if (cmdArg == "Delete")
                {
                    int index = int.Parse(command[1]);

                    if (index < 0 || index >= colection.Count - 1)
                    {
                        continue;
                    }
                    else
                    {
                        colection.RemoveAt(index + 1);
                    }

                }
                else if (cmdArg == "Swap")
                {                 
                    {
                        string firstWord = command[1];
                        string secondWord = command[2];

                        if (colection.Contains(firstWord) && colection.Contains(secondWord))
                        {
                            int indexFirst = colection.IndexOf(firstWord);
                            int indexSecond = colection.IndexOf(secondWord);

                            colection[indexFirst] = secondWord;
                            colection[indexSecond] = firstWord;
                        }
                    }
                }                
                                
                else if (cmdArg == "Put")
                {
                    string word = command[1];
                    int index = int.Parse(command[2]);

                    if (index < 1 || index >= colection.Count)
                    {
                        continue;
                    }
                    else
                    {
                        colection.Insert(index -1, word);
                    }

                }
                else if (cmdArg == "Replace")
                {
                    string wordOne = command[1];
                    string wordTwo = command[2];

                    if (colection.Contains(wordTwo))
                    {
                        for (int i = 0; i < colection.Count; i++)
                        {
                            if (wordTwo == colection[i])
                            {
                                colection[i] = wordOne;
                                break;
                            }
                        }
                    }

                }
            }
            Console.WriteLine(string.Join(" ", colection));
        }   
    }
}
