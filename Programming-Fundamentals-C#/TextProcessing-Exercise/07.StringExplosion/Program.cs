using System;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            var feild = Console.ReadLine();
            int bomb = 0;

            for (int i = 0; i < feild.Length; i++)
            {
                var currentChar = feild[i];

                if (feild[i] == '>')
                {
                    bomb += int.Parse(feild[i + 1].ToString());
                    continue;
                }

                if (bomb > 0)
                {
                    feild = feild.Remove(i, 1);
                    i--;
                    bomb--;
                }
            }
            Console.WriteLine(feild);
        }
    }
}
