using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> currentItems = Console.ReadLine()
                                        .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();            

            bool isCraftTime = false;

            while (isCraftTime != true)
            {
                string[] command = Console.ReadLine()
                                          .Split("-",StringSplitOptions.RemoveEmptyEntries)
                                          .ToArray();
                string cmdArg = command[0].TrimStart().TrimEnd(); 

                if (cmdArg == "Craft!")
                {
                    isCraftTime = true;
                    break;
                }

                string item = command[1].TrimStart().TrimEnd(); 

                List<string> inputCommand = new List<string>();
                string oldItem = string.Empty.TrimStart().TrimEnd(); 
                string newItem = string.Empty.TrimStart().TrimEnd(); 

                switch (cmdArg)
                {
                    case "Collect":

                        if (currentItems.Contains(item))
                        {
                            continue;
                        }
                        else
                        {
                            currentItems.Add(item);
                        }                        
                        break;
                    case "Drop":
                        if (currentItems.Contains(item))
                        {
                            currentItems.Remove(item);
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "Combine Items":
                        inputCommand = item.Split(":")
                                           .ToList();
                        oldItem = inputCommand[0].TrimStart().TrimEnd();
                        newItem = inputCommand[1].TrimStart().TrimEnd();

                        if (currentItems.Contains(oldItem))
                        {
                            currentItems.Add(newItem);
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "Renew":

                        string currentItem = item;

                        for (int i = 0; i < currentItems.Count; i++)
                        {
                            if (currentItem == item)
                            {                               
                                currentItems.RemoveAt(i);
                                currentItems.Insert(currentItems.Count, currentItem);
                                break;
                            }
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ",currentItems));
            
        }
    }
}
