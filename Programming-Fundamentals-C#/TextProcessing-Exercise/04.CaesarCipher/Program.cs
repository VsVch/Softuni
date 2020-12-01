using System;
using System.Text;

namespace _04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            StringBuilder criptedTex = new StringBuilder();

            
            for (int i = 0; i < input.Length; i++)
            {
                int ch = input[i] + 3;

                char charCh =(char)ch;
              
                criptedTex.Append(charCh);
            }
            Console.WriteLine(criptedTex);
        }
        
    }
}
