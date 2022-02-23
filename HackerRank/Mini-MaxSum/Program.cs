using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'miniMaxSum' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void miniMaxSum(List<int> arr)
    {
       arr.Sort();

        long minSum = 0;
        long maxSum = 0;

        for (int i = 0; i < arr.Count; i++)
        {
            var num = arr[i];

            if (i > 0)
            {
                maxSum += num;
            }

            if (i < arr.Count - 1)
            {
                minSum += num;
            }
        }
        var result = new List<long> { minSum, maxSum };

        Console.WriteLine(String.Join(' ', result));
    }
}

class Solution
{
    public static void Main(string[] args)
    {

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.miniMaxSum(arr);
    }
}