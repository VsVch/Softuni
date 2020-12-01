using System;
using System.Linq;
using System.Text;

namespace _03.TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string messege;

            while ((messege = Console.ReadLine()) != "find")
            {

                int startKey = 0;

                StringBuilder criptedMessege = new StringBuilder();

                for (int i = 0; i < messege.Length; i++)               
                {
                    
                    for (int j = key[startKey]; j < key.Length; j++)
                    {                                            
                        criptedMessege.Append((char)(messege[i] - key[startKey]));

                        if (key[startKey] == key.Length - 1)
                        {
                            startKey = 0;
                        }
                        else
                        {
                            startKey++;
                        }
                        break;
                    }
                }
                string decriptedText = criptedMessege.ToString();

                int startIndexType = decriptedText.IndexOf('&') + 1;

                int endIndexType = decriptedText.LastIndexOf('&');

                string type = decriptedText.Substring(startIndexType, endIndexType - startIndexType);

                int startIndex = decriptedText.IndexOf('<') + 1;

                int endIndex = decriptedText.IndexOf('>');

                string coordinates = decriptedText.Substring(startIndex, endIndex - startIndex);

                Console.WriteLine($"Found {type} at {coordinates}");
            }

        }
    }
}
