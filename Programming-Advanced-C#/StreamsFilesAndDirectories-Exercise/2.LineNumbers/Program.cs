using System;
using System.IO;
using System.Text.RegularExpressions;

namespace _2.LineNumbers
{
    class Program
    {
       

        static void Main(string[] args)
        {
           
           string[] lines = File.ReadAllLines("../../../text.txt");

            string[] newLines = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int countOflettars = CountOfLetter(line);
                int countOfMarks = CountOfMarks(line);

                newLines[i] = $"Line {i + 1}: {line} ({countOflettars}) ({countOfMarks})";
            }
            File.WriteAllLines("../../../output.txt", newLines);
            
            
        }

        private static int CountOfLetter(string line)
        {

            int counterLetter = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char ch = line[i];               

                if (char.IsLetter(ch))
                {
                    counterLetter++;
                }
            }

            return counterLetter;
        }
        private static int CountOfMarks(string line) 
        {
            int counter = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char ch = line[i];

                if (char.IsPunctuation(ch))
                {
                    counter++;
                }                
            }
            return counter;
        }
    }
}
