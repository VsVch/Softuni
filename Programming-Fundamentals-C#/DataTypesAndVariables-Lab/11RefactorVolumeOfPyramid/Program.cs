using System;

namespace _11RefactorVolumeOfPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            double length, width, height = 0;
            length = double.Parse(Console.ReadLine());
           
            width = double.Parse(Console.ReadLine());
            
            height = double.Parse(Console.ReadLine());
            
            double b = length * width;
            double volumeOfPyramid = (b * height) / 3;                     
                       
                   
            Console.Write($"Length: Width: Height: Pyramid Volume: {volumeOfPyramid:f2}");

        }
    }
}
