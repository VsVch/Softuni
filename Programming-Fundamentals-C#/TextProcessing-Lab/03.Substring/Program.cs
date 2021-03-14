using System;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string removeWord = Console.ReadLine().ToLower();

            string text = Console.ReadLine().ToLower();

            int index = text.IndexOf(removeWord.ToLower());

            while (index != -1)
            {
               text =text.Remove(index, removeWord.Length);

                index = text.IndexOf(removeWord);
            }

            Console.WriteLine(text);
        }
    }
}
