using System;

namespace _06.TournamentofChristmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberDays = int.Parse(Console.ReadLine());
            int countWin = 0;
            int countLose = 0;
            double money = 0;
            
            for (int i = 1; i <= numberDays; i++)
            {
                double moneyPerDay = 0;
                int countWinPerSet = 0;
                int countLosePerSet = 0;
                string sport = Console.ReadLine();
                while (true)
                {
                    
                    string result = Console.ReadLine();
                    if (result == "Finish")
                    {
                        if (countWinPerSet > countLosePerSet)
                        {
                            moneyPerDay = moneyPerDay * 1.1;
                            money += moneyPerDay;
                            countWin += countWinPerSet;
                        }
                        else
                        {
                            money += moneyPerDay;
                            countLose += countLosePerSet;
                        }
                        break;                        
                    }                    
                    if (result == "win")
                    {
                        countWinPerSet++;
                        moneyPerDay += 20;
                    }
                    else if (result == "lose")
                    {
                        countLosePerSet++;
                    }                   
                }                
            }
            if (countWin > countLose)
            {
                money = money * 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {money:f2}");               
            }
            else if (countWin < countLose)
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {money:f2}");                
            }
            
        }
    }
}
