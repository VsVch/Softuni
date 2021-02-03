using System;

namespace _05.DateModifierProblem
{
    public class DateModifierproblem
    {
        static void Main(string[] args)
        {
            
            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();

            int days = DateModifier.GetDefferencBetweenDateInDays(dateOne , dateTwo);

            Console.WriteLine(days);
        }
    }
}
