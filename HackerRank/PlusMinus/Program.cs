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
    public static void plusMinus(List<int> arr)
    {
        double zeroEqualsValues = 0;
        double lessThanZeroValues = 0;
        double moreThanZeroValues = 0;

        double arrayLength = arr.Count;

        for (int i = 0; i < arr.Count; i++)
        {
            double num = arr[i];

            if (num == 0)
            {
                zeroEqualsValues++;
            }
            else if (num > 0) 
            {
                moreThanZeroValues++;
            }
            else if (num < 0) 
            {
                lessThanZeroValues++;
            }
        }        

        var result = new List<string>() 
           {(moreThanZeroValues / arrayLength).ToString("f6"),
            (lessThanZeroValues / arrayLength).ToString("f6"),
            (zeroEqualsValues / arrayLength).ToString("f6")};

        Console.WriteLine(string.Join(Environment.NewLine, result));
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.plusMinus(arr);
    }
}
