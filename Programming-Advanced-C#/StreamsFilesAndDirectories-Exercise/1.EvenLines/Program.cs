using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {

            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {

                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    string line = reader.ReadLine();
                    int counter = 0;

                    while (line != null)                  
                    {                 
                     
                        if (counter % 2 == 0)
                        {
                            Regex pattern = new Regex(@"[,.\-!?]");
                            line = pattern.Replace(line, "@");
                            var array = line.Split().ToArray().Reverse();

                            writer.WriteLine(string.Join(" ", array));
                        }
                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }           

           
        }
    }
}
