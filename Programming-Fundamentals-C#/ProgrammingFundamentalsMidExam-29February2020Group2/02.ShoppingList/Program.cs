using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inicialList = Console.ReadLine()
                                              .Split("!")
                                              .ToList();

            List<string> command = Console.ReadLine()
                                      .Split(" ")
                                      .ToList();

            
            while (command[0] != "Go" && command[1] != "Shopping!")
            {
                string cmdArg = command[0];
                               
                string item = command[1];
                               
                switch (cmdArg)
                {
                    case "Urgent":

                        if (inicialList.Contains(item))
                        {
                            break;
                        }
                        else
                        {
                            inicialList.Add(item);
                            for (int i = inicialList.Count - 2; i >= 0; i--)
                            {                                                 
                                                                                 
                                 inicialList[i + 1] = inicialList[i];
                            }
                            inicialList[0] = item;
                        }
                        break;
                    case "Unnecessary":

                        if (inicialList.Contains(item))
                        {
                            inicialList.Remove(item);
                        }
                        break;
                    case "Correct":
                                                
                        if (inicialList.Contains(item))
                        {
                            
                            for (int i = 0; i < inicialList.Count; i++)
                            {
                                if (inicialList[i] == command[1])
                                {
                                    inicialList.Remove(inicialList[i]);

                                    inicialList.Insert(i, command[2]);
                                }
                            }
                        }
                        
                        break;
                    case "Rearrange":

                        if (inicialList.Contains(item))
                        {
                            for (int i = 0; i < inicialList.Count; i++)
                            {
                                if (inicialList[i] == item)
                                {
                                    inicialList.Remove(inicialList[i]);

                                    inicialList.Add(item);
                                }
                            }
                        }
                        break;
                                 
                }
                command = Console.ReadLine()
                                      .Split(" ")
                                      .ToList();

               
            }
            Console.WriteLine(string.Join(", " ,inicialList));
        }
    }
}
