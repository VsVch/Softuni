using System;

namespace _01.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {

            string inputKey = Console.ReadLine();

            string key = inputKey;

            string input;           

            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] command = input
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                string cmdArg = command[0];

                switch (cmdArg)
                {
                    case "Contains":
                        string substring = command[1];

                        if (key.Contains(substring))
                        {
                            Console.WriteLine($"{key} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine($"Substring not found!");
                        }
                        break;
                    case "Flip":
                        string directions = command[1];

                        int startIndex = int.Parse(command[2]);

                        int endtIndex = int.Parse(command[3]);

                        string firstPart = key.Substring(0, startIndex);

                        string secondPart = key.Substring(startIndex, endtIndex - startIndex);

                        string thirdPart = key.Substring(endtIndex);

                        if (directions == "Upper")
                        {
                            secondPart = key.Substring(startIndex, endtIndex - startIndex).ToUpper();
                        }
                        else
                        {
                            secondPart = key.Substring(startIndex, endtIndex - startIndex).ToLower();
                        }

                        key = firstPart + secondPart + thirdPart;

                        Console.WriteLine(key);
                        break;
                    case "Slice":
                        startIndex = int.Parse(command[1]);
                        endtIndex = int.Parse(command[2]);

                        key = key.Remove(startIndex, endtIndex - startIndex);

                        Console.WriteLine(key);

                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"Your activation key is: {key} ");
        }
    }
}
