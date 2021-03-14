using System;

namespace _07.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstToken = Console.ReadLine().Split(" ");
            string fullName = $"{firstToken[0]} {firstToken[1]}";
            string addres = firstToken[2];
            Tuple<string, string> tupleprsonInfo = new Tuple<string, string>(fullName, addres);
            Console.WriteLine(tupleprsonInfo);

            string[] secondToken = Console.ReadLine().Split(" ");
            string personName = secondToken[0];
            int litersBeer = int.Parse(secondToken[1]);
            Tuple<string, int> drinkedBeer = new Tuple<string, int>(personName, litersBeer);
            Console.WriteLine(drinkedBeer);

            string[] thirdToken = Console.ReadLine().Split(" ");
            int intNumber = int.Parse(thirdToken[0]);
            double doubleNumber = double.Parse(thirdToken[1]);
            Tuple<int, double> differentNumbers = new Tuple<int, double>(intNumber, doubleNumber);
            Console.WriteLine(differentNumbers);



        }
    }
}
