using System;

namespace _02.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            //int period = int.Parse(Console.ReadLine());

            //int treatedPatients = 0;
            //int untreatedPacients = 0;

            //for (int i = 1; i < 3; i++)
            //{
            //    int numberOfPatients = int.Parse(Console.ReadLine());
            //    if (numberOfPatients <= 7)
            //    {

            //        treatedPatients += numberOfPatients;
            //    }
            //    else if (numberOfPatients > 7)
            //    {
            //        untreatedPacients += numberOfPatients - 7;
            //        treatedPatients += 7;
            //    }

            //}
            //if (treatedPatients < untreatedPacients)
            //{

            //    for (int i = 3; i <= period; i++)
            //    {
            //        int numberOfPatients = int.Parse(Console.ReadLine());
            //        if (numberOfPatients <= 8)
            //        {

            //            treatedPatients += numberOfPatients;
            //        }
            //        else if (numberOfPatients > 8)
            //        {
            //            untreatedPacients += numberOfPatients - 8;
            //            treatedPatients += 8;
            //        }
            //    }

            //}
            //else if (treatedPatients >= untreatedPacients)
            //{
            //    int numberOfPatients = int.Parse(Console.ReadLine());
            //    for (int i = 3; i <= period; i++)

            //        if (numberOfPatients <= 7)
            //        {

            //            treatedPatients += numberOfPatients;
            //        }
            //        else if (numberOfPatients > 7)
            //        {
            //            untreatedPacients += numberOfPatients - 7;
            //            treatedPatients += 7;
            //        }

            //}
            //Console.WriteLine($"Treated patients: {treatedPatients}.");
            //Console.WriteLine($"Untreated patients: {untreatedPacients}.");

            int period = int.Parse(Console.ReadLine());
            int treatedPatients = 0;
            int untreatedPacients = 0;

            for (int i = 1; i <= period; i++)
            {
                int numberOfPatients = int.Parse(Console.ReadLine());
                if (period <= 4)
                {
                    if (numberOfPatients <= 7)
                    {
                        treatedPatients += numberOfPatients;
                    }
                    else if (numberOfPatients > 7)
                    {
                        untreatedPacients += numberOfPatients - 7;
                        treatedPatients += 7;
                    }
                }
                 
                
                

                
            }
        }
    }
}
