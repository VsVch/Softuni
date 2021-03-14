using System;

namespace _05.GameOfIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int input = int.Parse(Console.ReadLine());

            const double convector = 1.0;
            double score = 0;
            double invalideNumbers = 0;
            double numbers9 = 0;
            double numbers1019 = 0;
            double numbers2029 = 0;
            double numbers3039 = 0;
            double numbers4050 = 0;

            for (int i = 0; i < input; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number >= 0 && number <= 9)
                {
                    score += convector * number * 20 / 100;
                    numbers9++;
                }
                else if (number >= 10 && number <= 19)
                {
                    score += convector * number * 30 / 100;
                    numbers1019++;
                }
                else if (number >= 20 && number <= 29)
                {
                    score += convector * number * 40 / 100;
                    numbers2029++;
                }
                else if (number >= 30 && number <= 39)
                {
                    score += 50;
                    numbers3039++;
                }
                else if (number >= 40 && number <= 50)
                {
                    score += 100;
                    numbers4050++;
                }
                else
                {
                    score /= 2;
                    invalideNumbers++;
                }
            }
            double percentNumbers9 = numbers9 * 100 / input;
            double percentNumbers1019 = numbers1019 * 100 / input;
            double percentNumbers2029 = numbers2029 * 100 / input;
            double percentNumbers3039 = numbers3039 * 100 / input;
            double percentNumbers4050 = numbers4050 * 100 / input;
            double percentinvalideNumbers = invalideNumbers * 100 / input;

            Console.WriteLine($"{score:f2}");
            Console.WriteLine($"From 0 to 9: {percentNumbers9:f2}%");
            Console.WriteLine($"From 10 to 19: {percentNumbers1019:f2}%");
            Console.WriteLine($"From 20 to 29: {percentNumbers2029:f2}%");
            Console.WriteLine($"From 30 to 39: {percentNumbers3039:f2}%");
            Console.WriteLine($"From 40 to 50: {percentNumbers4050:f2}%");
            Console.WriteLine($"Invalid numbers: {percentinvalideNumbers:f2}%");
        }
    }
}
