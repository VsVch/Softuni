using System;

namespace FibonacciNumbers 
{
    public class Program
    {
        static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());

            var fibonacciArray = new FibonacciArray(n);

            fibonacciArray.Add(n);

            fibonacciArray.Print();

            Console.WriteLine(fibonacciArray.Show(1));
        }
    }

    public class FibonacciArray
    {
        private int[] array;
        private int Count;

        public FibonacciArray(int n)
        {
            this.array = new int[n];
        }

        public void Add(int n)
        {           
            
            array[0] = 0;
            array[1] = 1;

            Count += 2;

            while (true)
            {
                AddFibunacciNumber(array[Count - 2], array[Count - 1]);
                
                if (Count == n)
                {
                    break;
                }
            }
        }

        public void Print()
        {
            Console.WriteLine(String.Join(" ", array));
        }

        public string Show(int num)
        {
            if (num > 0 && num <= Count)
            {
                return array[num - 1].ToString();
            }

            return $"This number '{num}' is outside from the collection boundary.";

        }

        private void AddFibunacciNumber(int numOne, int numTwo)
        {
            var num = numOne + numTwo;
            array[Count] = num;
            Count++;
        }


    }
}
