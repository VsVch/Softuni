using System;
using System.Linq;

namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ");
                      

            for (int i = 0; i < input.Length; i++)
            {
              var  password = input[i];

                if (IsValide(password))
                {   
                    Console.WriteLine(password);
                }
            }
        }
        static private bool IsValide(string item)
        {

            return item.Length >= 3 && item.Length <= 16 && 
                item.All(i => char.IsLetterOrDigit(i) || 
                item.Contains('-') || item.Contains('_'));
                
        }
    }
}
