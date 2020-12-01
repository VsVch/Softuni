using System;

namespace _04.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannWords = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                ;
            string text = Console.ReadLine();

            foreach (var word in bannWords)
            {
               string replace = new string('*', word.Length);
               text = text.Replace(word, replace);
            }
            Console.WriteLine(text);
        }
    }
}
