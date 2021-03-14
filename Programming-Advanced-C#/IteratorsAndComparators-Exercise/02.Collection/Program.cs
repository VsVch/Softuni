using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Collection
{
   public class StartUp
   {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(" ").Skip(1).ToList();

            ListyIterator<string> list = new ListyIterator<string>(items);

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] array = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = array[0];

                switch (command)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            list.Print();
                        }
                        catch (InvalidOperationException)
                        {

                            Console.WriteLine("Invalid Operation!");
                        }
                        break;

                    case "PrintAll":
                        foreach (string item in list)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                        break;
                    default:
                        break;
                }
            }
        }
   }
}
