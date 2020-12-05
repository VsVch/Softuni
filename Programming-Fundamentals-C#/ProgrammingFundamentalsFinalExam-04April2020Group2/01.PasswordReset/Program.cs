using System;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            

            string command;

            string newString = Console.ReadLine();

            while ((command = Console.ReadLine()) != "Done")
            {
                string[] tokens = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdArg = tokens[0];

                if (cmdArg == "TakeOdd")
                {
                    string oddLetter = string.Empty;

                    for (int  i = 0;  i < newString.Length;  i++)
                    {
                        if (i % 2 != 0)
                        {
                            oddLetter += newString[i];
                        }
                    }
                    newString = oddLetter;

                    Console.WriteLine(newString);
                }
                else if (cmdArg == "Cut")
                {
                    int index = int.Parse(tokens[1]);
                    int length = int.Parse(tokens[2]);

                    newString = newString.Remove(index, length);

                    Console.WriteLine(newString);
                }
                else if (cmdArg == "Substitute")
                {
                    string substring = tokens[1];
                    string substitute = tokens[2];

                    if (newString.Contains(substring))
                    {
                        newString = newString.Replace(substring, substitute);
                        Console.WriteLine(newString);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }

            Console.WriteLine($"Your password is: {newString}");

        }
    }
}
