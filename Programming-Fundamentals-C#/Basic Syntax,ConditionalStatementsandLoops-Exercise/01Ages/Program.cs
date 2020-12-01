using System;

namespace _01Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            string ageTipe = string.Empty;
            if (age >= 0 && age <= 2)
            {
                ageTipe = "baby";
            }
            else if (age >= 3 && age <= 13)
            {
                ageTipe = "child";
            }
            else if (age >= 14 && age <= 19)
            {
                ageTipe = "teenager";
            }
            else if (age >= 20 && age <= 65)
            {
                ageTipe = "adult";
            }
            else if (age >= 66)
            {
                ageTipe = "elder";
            }
            Console.WriteLine($"{ageTipe}");
        }
    }
}
