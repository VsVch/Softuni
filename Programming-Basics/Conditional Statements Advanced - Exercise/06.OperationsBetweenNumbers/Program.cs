using System;
using System.Xml.Schema;

namespace _06.OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            string symbol = Console.ReadLine();
            if (n2 == 0)
            {
                Console.WriteLine($" Cannot divide {n1} by zero");
            }

                if (symbol == "+")
                {
                    double sum = n1 + n2;
                    if (sum % 2 == 0)
                    {
                        Console.WriteLine($"{n1} {symbol} {n2} = {sum} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{n1} {symbol} {n2} = {sum} - odd");
                    }
                }
                else if (symbol == "-")
                {
                    double deference = n1 - n2;
                    if (deference % 2 == 0)
                    {
                        Console.WriteLine($"{n1} {symbol} {n2} = {deference} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{n1} {symbol} {n2} = {deference} - odd");
                    }
                }
                else if (symbol == "*")
                {
                    double multiplication = n1 * n2;
                    if (multiplication % 2 == 0)
                    {
                        Console.WriteLine($"{n1} {symbol} {n2} = {multiplication} - even");
                    }
                    else if (multiplication % 2 == 1)
                    {
                        Console.WriteLine($"{n1} {symbol} {n2} = {multiplication} - odd");
                    }
                    else if (n2 == 0)
                    {
                        Console.WriteLine($" Cannot divide {n1} by zero");
                    }
                }
                else if (symbol == "/")
                {
                    if (n2 != 0)
                    {
                        double division = n1 / n2;
                        Console.WriteLine($"{n1} {symbol} {n2} = {division:f2}");


                    }
                }

                else if (symbol == "%" && n2 != 0)
                {
                    if (n1 % n2 == 0)
                    {
                        double multipleDivision = n1 % n2;
                        Console.WriteLine($"{n1} {symbol:f2} {n2} = {multipleDivision}");
                    }
                    else if (n1 % n2 == 1)
                    {
                        double sum = n1 % n2;
                        Console.WriteLine($"{n1} {symbol:f2} {n2} = {sum}");
                    }
                    else if (n2 % n1 == 0)
                    {
                        double sum = n2 % n1;
                        Console.WriteLine($"{n1} {symbol:f2} {n2} = {sum}");
                    }
                    else if (n2 % n1 == 1)
                    {
                        double sum = n2 % n1;
                        Console.WriteLine($"{n1} {symbol:f2} {n2} = {sum}");
                    }
                }
                          

            
        }
    }
}
