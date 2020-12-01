using System;

namespace _06.Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            int mounts = int.Parse(Console.ReadLine());
            const double convector = 1.0;
            const double watar = 20;
            const double internet = 15;

            double other = 0;        
            double electrisity = 0;                    
            
            for (int i = 1; i <= mounts; i++)
            {
                double electricityPerMounth = double.Parse(Console.ReadLine());

                electrisity += electricityPerMounth;
                other += (electricityPerMounth + watar + internet) + ((electricityPerMounth + watar + internet) * 20 / 100);

            }
            double waterCost = watar * mounts;
            double internetCost = internet * mounts;
            double averegePerMounth = (waterCost + internetCost + other + electrisity) / mounts;
            Console.WriteLine($"Electricity: {electrisity:f2} lv");
            Console.WriteLine($"Water: {waterCost:f2} lv");
            Console.WriteLine($"Internet: {internetCost:f2} lv");
            Console.WriteLine($"Other: {other:f2} lv");
            Console.WriteLine($"Average: {averegePerMounth:f2} lv");
        }
        
    }
}
