using System;

namespace SampleNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
          int n = int.Parse(Console.ReadLine());

            SampleNumbersArray sampleNumArray = new SampleNumbersArray(n);

            for (int i = 0; i < n; i++)
            {
               var number = int.Parse(Console.ReadLine());

                sampleNumArray.CheckSampleNumber(number);
            }

            sampleNumArray.PrintArray();
        }
    }    
}

public class SampleNumbersArray
{
    private int count = 0;
    public SampleNumbersArray(int n)
    {
        this.Array = new int[n];
    }

    public int [] Array { get; set; }


    public void CheckSampleNumber(int number)
    {
        int [] numbers = new int [] {2, 3, 4, 5, 6, 7, 8, 9};

        bool isSampleNumber = true;

        for (int i = 0; i < numbers.Length; i++)
        {
            double curNum = 1.0 * number / numbers[i];

            if (isInteger(curNum) == true && number / numbers[i] != 1)
            {
                isSampleNumber = false;
                break;
            }        
        }

        if (isSampleNumber && number != 1)
        {
            Add(number);
        }
    }

    public void PrintArray()
    {
        Console.WriteLine(String.Join(' ', Array.Where(e => e != 0)));
    }

    private void Add(int number) 
    {
        count++;
        this.Array[count] = number;
    }

    private bool isInteger(double currNumber)
    {
        int intValue = (int)currNumber;
        return currNumber == intValue;
    }
}