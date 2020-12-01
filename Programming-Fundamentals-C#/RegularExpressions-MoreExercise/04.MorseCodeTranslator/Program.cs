using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string input = Console.ReadLine();

            List<string> morseCode = input
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .ToList();

            StringBuilder messeg = new StringBuilder();

            bool isEndOfTheList = false;

            while (isEndOfTheList != true)
            {
                // to do stop 

                char alphabet = ' ';

                switch (morseCode[0])
                {
                    case "|":
                        alphabet = '|';
                        break;
                    case ".-":
                        alphabet = 'A';
                        break;
                    case "-...":
                        alphabet = 'B';
                        break;
                    case "-.-.":
                        alphabet = 'C';
                        break;
                    case "-..":
                        alphabet = 'D';
                        break;
                    case ".":
                        alphabet = 'E';
                        break;
                    case "..-.":
                        alphabet = 'F';
                        break;
                    case "--.":
                        alphabet = 'G';
                        break;
                    case "....":
                        alphabet = 'H';
                        break;
                    case "..":
                        alphabet = 'I';
                        break;
                    case ".---":
                        alphabet = 'J';
                        break;
                    case "-.-":
                        alphabet = 'K';
                        break;
                    case ".-..":
                        alphabet = 'L';
                        break;
                    case "--":
                        alphabet = 'M';
                        break;
                    case "-.":
                        alphabet = 'N';
                        break;
                    case "---":
                        alphabet = 'O';
                        break;
                    case ".--.":
                        alphabet = 'P';
                        break;
                    case "--.-":
                        alphabet = 'Q';
                        break;
                    case ".-.":
                        alphabet = 'R';
                        break;
                    case "...":
                        alphabet = 'S';
                        break;
                    case "-":
                        alphabet = 'T';
                        break;
                    case "..-":
                        alphabet = 'U';
                        break;
                    case "...-":
                        alphabet = 'V';
                        break;
                    case ".--":
                        alphabet = 'W';
                        break;
                    case "-..-":
                        alphabet = 'X';
                        break;
                    case "-.--":
                        alphabet = 'Y';
                        break;
                    case "--..":
                        alphabet = 'Z';
                        break;

                }
                messeg.Append((char)alphabet);

                morseCode.RemoveAt(0);

                if (morseCode.Count == 0)
                {
                    isEndOfTheList = true;
                }
            }
            messeg.Replace('|', ' ');

            Console.WriteLine(messeg);
             // on second test responce "that was plesure for me"
        }
    }
}
