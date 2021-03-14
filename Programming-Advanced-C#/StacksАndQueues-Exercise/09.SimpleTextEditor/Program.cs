using System;
using System.Collections.Generic;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> commands = new Queue<string>();

            Stack<string> undos = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                commands.Enqueue(input);
            }

            string emptyString = string.Empty;

            while (commands.Count > 0)
            {
                string currentCommand = commands.Dequeue();
                string[] command = currentCommand.Split(" ");
                string cmdArg = command[0];

                if (cmdArg == "1")
                {
                    undos.Push(emptyString);
                    string text = command[1];
                    emptyString = emptyString + text;
                    
                }
                else if (cmdArg == "2")
                {
                    int index = int.Parse(command[1]);
                    undos.Push(emptyString);
                    emptyString = emptyString.Remove(emptyString.Length - index, index);
                }
                else if (cmdArg == "3")
                {
                    int index = int.Parse(command[1]);

                    for (int i = 1; i <= emptyString.Length; i++)
                    {
                        if (i == index)
                        {
                            Console.WriteLine(emptyString[i - 1]);
                            break;
                        }
                    }
                }
                else if (cmdArg == "4")
                {
                    emptyString = undos.Pop();
                }
            }
        }
    }
}
