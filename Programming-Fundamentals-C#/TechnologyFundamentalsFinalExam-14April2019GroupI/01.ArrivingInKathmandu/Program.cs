using System;

namespace _01.ArrivingInKathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            input = String.Join("", input.Split('@', '!', '#', '$', '?')); // "!" "@" "#" "$" "?"

            for (int i = 0; i < input.Length; i++)
            {
                if (true)
                {

                }
            }

            Console.WriteLine(input);
        }
    }
}
