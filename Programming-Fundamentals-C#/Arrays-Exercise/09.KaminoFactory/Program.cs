using System;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string input = string.Empty;
            int counter = 0;
            int bestCount = 0;
            int bestBegineInex = 0;
            int bestSum = 0;
            string bestSequence = "";
            int bestConter = 0;
            while ((input = Console.ReadLine()) != "Clone them!")
            {
                string sequence = input.Replace("!", "");

                string[] dnaParts = sequence
                    .Split("0", StringSplitOptions.RemoveEmptyEntries);

                int count = 0;
                int sum = 0;
                string bestSubSequence = "";
                counter++;

                foreach (string dnaPart in dnaParts)
                {
                    if (dnaPart.Length > count)
                    {
                        count = dnaPart.Length;
                        bestSubSequence = dnaPart;
                    }
                    sum += dnaPart.Length;
                }
                int begineIndex = sequence.IndexOf(bestSubSequence);
                if (count > bestCount ||
                    (count == bestCount && begineIndex < bestBegineInex) ||
                    (count == bestCount && begineIndex ==bestBegineInex && sum > bestSum))
                {
                    bestCount = count;
                    bestSequence = sequence;
                    bestBegineInex = begineIndex;
                    bestSum = sum;
                    bestConter = counter;
                }
            }

            char[] result = bestSequence.ToCharArray();
            Console.WriteLine($"Best DNA sample {bestConter} with sum: {bestSum}.");
            Console.WriteLine($"{string.Join("", result)}");
        }
    }
}
