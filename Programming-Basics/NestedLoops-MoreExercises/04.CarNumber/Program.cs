using System;

namespace _04.CarNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int startNum = 0;
            int endNum = 0;
            for (int i = start; i <= end; i++)
            {
                startNum = i;
                for (int j = start; j <= end; j++)
                {
                    for (int k = start; k <= end; k++)
                    {
                        for (int l = start; l <= end; l++)
                        {
                            int sum = j + k;
                            endNum = l;
                            if (startNum > endNum)
                            {
                                if (sum % 2 == 0)
                                {
                                    if (i % 2 == 0 && l % 2 != 0)
                                    {
                                        Console.Write($"{i}{j}{k}{l} ");

                                    }
                                    else if (i % 2 != 0 && l % 2 == 0)
                                    {

                                        Console.Write($"{i}{j}{k}{l} ");
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
