using System;
using System.Linq;

namespace _01.WorldТour
{
    class Program
    {
        static void Main(string[] args)
        {
            string destinations = Console.ReadLine();

            string input;

            while ((input = Console.ReadLine()) != "Travel")
            {
                string[] command = input
                    .Split(":");
                

                if (command.Contains("Add Stop")) // {index}:{string}
                {
                    int index = int.Parse(command[1]);
                    string substring = command[2];

                    if (index >= 0 && index < destinations.Length) // ?
                    {
                        destinations = destinations.Insert(index, substring);
                    }
                    else
                    {                       
                        
                    }
                    
                }
                else if (command.Contains("Remove Stop")) // {start_index}:{end_index}
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    if (startIndex >= 0 && endIndex >= 0 && endIndex <= destinations.Length - 1)
                    {
                        destinations = destinations.Remove(startIndex, endIndex - startIndex + 1);
                    }
                    else
                    {
                                   

                    }
                    
                }
                else if (command.Contains("Switch")) // {old_string}:{new_string} 
                {
                    string oldString = command[1];
                    string newString = command[2];

                    if (!destinations.Contains(oldString))
                    {
                        
                    }
                    else
                    {
                        destinations = destinations.Replace(oldString, newString);                        
                    }
                    
                }
                Console.WriteLine(destinations);

            }
            Console.WriteLine($"Ready for world tour! Planned stops: {destinations}");
        }
    }
}
