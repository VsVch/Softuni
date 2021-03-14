using System;

namespace _08.Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] token1 = Console.ReadLine().Split(" ");  

            string name = $"{token1[0]} {token1[1]}";
            string addres = token1[2];
            string town =$"{token1[3]} {token1[4]}";
            Threeuple<string, string, string> personInfo = 
                new Threeuple<string, string, string>(name, addres, town);
            Console.WriteLine(personInfo);

            string[] token2 = Console.ReadLine().Split(" "); 

            string drinkerName = token2[0];
            int beer =int.Parse(token2[1]);
            string dilema = token2[2];
            Threeuple<string, int, string> beersDilema = 
                new Threeuple<string, int, string>(drinkerName, beer, dilema);
            Console.WriteLine(beersDilema);

            string[] token3 = Console.ReadLine().Split(" "); 

            string userName = token3[0];
            double balance = double.Parse(token3[1]);
            string bank = token3[2];

            Threeuple<string, double, string> accountInfo = 
                new Threeuple<string, double, string>(userName,balance,bank);
            Console.WriteLine(accountInfo);     
        }
    }
}
