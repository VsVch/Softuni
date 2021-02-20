using System;
using System.Collections.Generic;

namespace YieldReturnNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerator<int> enumerator = GetNums().GetEnumerator();

            enumerator.MoveNext();

            var result = 0;

            result += enumerator.Current;

            enumerator.MoveNext();

            result += enumerator.Current;

            enumerator.MoveNext();

            result += enumerator.Current;

            enumerator.MoveNext();

            result += enumerator.Current;

            Console.WriteLine(result);

        }

        static IEnumerable<int> GetNums()
        {
            yield return 5;
            Console.WriteLine("after first return");
            yield return 8;
            yield return 7;
            yield return 6;
            yield return 5;
            yield return 4;

        }


    }
}
