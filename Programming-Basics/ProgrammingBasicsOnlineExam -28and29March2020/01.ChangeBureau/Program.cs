using System;

namespace _01.ChangeBureau
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	1 биткойн = 1168 лева.
            //•	1 китайски юан = 0.15 долара.
            //•	1 долар = 1.76 лева.
            //•	1 евро = 1.95 лева.
            const double oneBitcoint = 1168;
            const double oneJuan = 0.15;
            const double oneDolar = 1.76;
            const double oneEuro = 1.95;
            double numberBitcoints = double.Parse(Console.ReadLine());
            double numberJuab = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine());
            double bitcointsToLeva = numberBitcoints * oneBitcoint;
            double juanToDolars = numberJuab * oneJuan;
            double juanToLeva = juanToDolars * 1.76;
            double totalLeva = bitcointsToLeva + juanToLeva;
            double totalEuro = totalLeva / 1.95;
            
            if (commission == 5)
            {
                double discount = totalEuro * 0.05;
                double total = totalEuro - discount;
                Console.WriteLine($"{total:f2}");
            }
            
        
        }
    }
}
