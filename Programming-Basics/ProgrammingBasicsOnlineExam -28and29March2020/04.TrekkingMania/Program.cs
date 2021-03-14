using System;

namespace _04.TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfGropes = int.Parse(Console.ReadLine());
            
            double musala = 0;
            double monblan = 0;
            double kilimandjaro = 0;
            double k2 = 0;
            double everest = 0;
            
            for (int i = 1; i <= numOfGropes; i++)
            {
                int numberOfPeoples = int.Parse(Console.ReadLine());
                if (numberOfPeoples <= 5)
                {
                    musala += numberOfPeoples;
                }
                else if (numberOfPeoples >= 6 && numberOfPeoples <= 12)
                {
                    monblan += numberOfPeoples;
                }
                else if (numberOfPeoples >= 13 && numberOfPeoples <= 25)
                {
                    kilimandjaro += numberOfPeoples;
                }
                else if (numberOfPeoples >= 26 && numberOfPeoples <= 40)
                {
                    k2 += numberOfPeoples;
                }
                else
                {
                    everest += numberOfPeoples;
                }
                
            }
            double allPeoples = musala + monblan + kilimandjaro + k2 + everest;
            double percentMusal = musala * 100 / allPeoples;
            double percentMonblan = monblan * 100 / allPeoples;
            double percentKilimandjaro = kilimandjaro * 100 / allPeoples;
            double percentK2 = k2 * 100 / allPeoples;
            double percentEverest = everest * 100 / allPeoples;
            Console.WriteLine($"{percentMusal:f2}%");
            Console.WriteLine($"{percentMonblan:f2}%");
            Console.WriteLine($"{percentKilimandjaro:f2}%");
            Console.WriteLine($"{percentK2:f2}%");
            Console.WriteLine($"{percentEverest:f2}%");

        }
    }
}
