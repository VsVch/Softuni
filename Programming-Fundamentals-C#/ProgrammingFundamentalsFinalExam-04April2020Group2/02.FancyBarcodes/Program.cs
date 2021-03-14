using System;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@#+[A-Z]([A-Za-z0-9]{4,})[A-Z]@#+";

            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string barCode = Console.ReadLine();

                Match match = regex.Match(barCode);

                if (match.Success)
                {
                    string number = string.Empty;

                    bool noDigits = false;

                    for (int j = 0; j < barCode.Length; j++)
                    {
                        if (char.IsDigit(barCode[j]))
                        {                          
                            number += barCode[j];
                            noDigits = true;
                        }                        
                    }
                    if (noDigits == false)
                    {
                        number = "00";
                    }
                    Console.WriteLine($"Product group: {number}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
