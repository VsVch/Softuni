using System;

namespace GenericMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintKeyValuePair<int, string>(5, "Gogi");
        }
        static void PrintKeyValuePair<TKey, TValue>(TKey key, TValue value) 
        {
            Console.WriteLine($"Key: {key} Value : {value}");      
        
        }
    }
}
