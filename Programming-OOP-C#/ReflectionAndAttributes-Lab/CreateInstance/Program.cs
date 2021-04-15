using System;
using System.Text;

namespace CreateInstance
{
    public class Program
    {
        static void Main(string[] args)
        {
            Type sbType = typeof(StringBuilder);

            StringBuilder sb = (StringBuilder)Activator.CreateInstance(sbType);
            StringBuilder whitArguments =
                (StringBuilder)Activator.CreateInstance(sbType, new object[] { "Hey hey" });
            Console.WriteLine(whitArguments);

            sb.Append("HELLO");
            Console.WriteLine(sb);
        }
    }
}
