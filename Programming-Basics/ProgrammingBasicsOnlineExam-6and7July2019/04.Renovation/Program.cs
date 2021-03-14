using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace _04.Renovation
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int wigth = int.Parse(Console.ReadLine());
            int percentAreaNotPainted = int.Parse(Console.ReadLine());
            bool sTop = false;
            int countlitersPaint = 0;
            int areaForPainting = height * wigth * 4;
            double paintedArea = 1.0 * areaForPainting - (areaForPainting * percentAreaNotPainted / 100);
            while (sTop != true)
            {
                string input = Console.ReadLine();
                if (input == "Tired!")
                {
                    sTop = true;

                }
                int litersPaint = int.Parse(input);
                countlitersPaint += litersPaint;              
                             
            }
            if (areaForPainting > countlitersPaint)
            {
                double metersLeft = areaForPainting - countlitersPaint;
                Console.WriteLine($"{metersLeft:f0} quadratic m left.");
            }
            else if (areaForPainting == countlitersPaint)
            {
                Console.WriteLine($"All walls are painted! Great job, Pesho!");
            }
            else if (areaForPainting < countlitersPaint)
            {
                double paintLeft = countlitersPaint - areaForPainting;
                Console.WriteLine($"All walls are painted and you have {paintLeft:f0} l paint left!");
            }
        }
    }
}
