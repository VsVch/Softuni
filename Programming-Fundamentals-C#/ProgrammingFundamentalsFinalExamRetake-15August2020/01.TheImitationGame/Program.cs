using System;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = Console.ReadLine();

            string input;

            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] command = input
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string cmdArg = command[0];

                if (cmdArg == "Move") // {number of letters}
                {
                    int numberOfLetters = int.Parse(command[1]);

                    string movingLetters = code.Substring(0, numberOfLetters);
                    code = code.Remove(0, numberOfLetters);
                    code = code.Insert(code.Length, movingLetters);

                }
                else if (cmdArg == "Insert") // {index} {value}
                {
                    int index = int.Parse(command[1]);
                    string value = command[2];

                    code = code.Insert(index, value);
                }
                else if (cmdArg == "ChangeAll") //{substring} {replacement}
                {
                    string substring = command[1];
                    string replacement = command[2];

                    code = code.Replace(substring, replacement);
                }
            }
            Console.WriteLine($"The decrypted message is: {code}");

        }
    }
}
