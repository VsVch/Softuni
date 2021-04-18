using System;
using System.Linq;

class Program
{
    static void Main(String[] args)
    {
        int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int n = arr[0];
        int m = arr[1];

        var numbers = new int[n + 1];

        for (int i = 0; i < m; i++)
        {
            arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int a = arr[0];
            int b = arr[1];
            int k = arr[2];

            numbers[a - 1] += k;
            numbers[b] -= k;
        }

        long sum = 0;
        long max = 0;

        foreach (var num in numbers)
        {
            sum += num;
            if (max < sum)
                max = sum;
        }

        Console.WriteLine(max);
    }
}
