using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.StealFieldInfo("Stealer.Hacher", new string[] { "username", "password" });
            Console.WriteLine(result);
        }
    }
}
