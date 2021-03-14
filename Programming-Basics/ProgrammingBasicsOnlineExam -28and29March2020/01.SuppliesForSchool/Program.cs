using System;

namespace _01.SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            const double pensCost = 5.8;
            const double markersCost = 7.2;
            const double boadrCliningCost = 1.2;

            int packetsPens = int.Parse(Console.ReadLine());
            int packetsMarkers = int.Parse(Console.ReadLine());
            double litersBoardCleaner = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());
            double packetPensPrace = packetsPens * 1.0 * pensCost;
            double packetMarkersCost = packetsMarkers * 1.0 * markersCost;
            double litersBoardCleanerCost = litersBoardCleaner * 1.0 * boadrCliningCost;
            double allMaterialsCost = packetPensPrace + packetMarkersCost + litersBoardCleanerCost;
            double materialCostWhitDiscount = allMaterialsCost - (allMaterialsCost * discount / 100);
            Console.WriteLine($"{materialCostWhitDiscount:f3}");

        }
    }
}
