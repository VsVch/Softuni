using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
	string result1 = Lowercase1("Test");
	string result2 = Lowercase2("Test"); // Call Lowercase2.
	string result3 = Lowercase2("Test"); // Call Lowercase2 again.
	Console.WriteLine("{0} {1} {2}", result1, result2, result3);
    }

    static string Lowercase1(string value)
    {
	return value.ToLower();
    }

    static Dictionary<string, string> _lowercase = new Dictionary<string, string>();
    static string Lowercase2(string value)
    {
	string lookup;
	if (_lowercase.TryGetValue(value, out lookup))
	    return lookup;

	lookup = value.ToLower();

	_lowercase[value] = lookup;
	return lookup;
    }
}