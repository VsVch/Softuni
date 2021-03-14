using System;

namespace _06.VowelsSum
{
    class Program
    {
        static void Main(string[] args)
        {

            //string input = Console.ReadLine();

            //int number = 0;

            //for(int i = 0; i < input.Length; i++)
            //{
            //    char currentLetter = input[i];
            //    if (currentLetter == 'a')
            //    {
            //        number += 1;
            //    }
            //    else if (currentLetter == 'e')
            //    {
            //        number += 2;
            //    }
            //    else if (currentLetter == 'i')
            //    {
            //        number += 3;
            //    }
            //    else if (currentLetter == 'o')
            //    {
            //        number += 4;
            //    }
            //    else if (currentLetter == 'u')
            //    {
            //        number += 5;
            //    }         

            //}
            //Console.WriteLine(number);
            string input = Console.ReadLine();
            int number = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char currentletter = input[i];
                switch (currentletter)
                {
                    case 'a':
                        number += 1;
                        break;
                    case 'e':
                        number += 2;
                        break;
                    case 'i':
                        number += 3;
                        break;
                    case 'o':
                        number += 4;
                        break;
                    case 'u':
                        number += 5;
                        break;
                        
                }
                Console.WriteLine(number);
            }

            


        }
    }
}

