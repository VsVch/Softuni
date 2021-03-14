using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();

            int result = VowelsCounter(input);

            Console.WriteLine(result);
        }

        private static int VowelsCounter(string input)
        {
            int counter = 0;
                        
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (currentChar == 'a' 
                    || currentChar == 'e' 
                    || currentChar == 'i' 
                    || currentChar == 'o' 
                    || currentChar == 'u' 
                    || currentChar == 'y') 
                {
                    counter++;
                }
                
            }
            
            return counter;
        }
    }
}
