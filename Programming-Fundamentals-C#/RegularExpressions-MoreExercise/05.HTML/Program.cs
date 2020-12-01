using System;
using System.Collections.Generic;

namespace _05.HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string articleName = Console.ReadLine(); // (<h1></h1>

            string content = Console.ReadLine(); // (<article></article>)

            string comment;

            List<string> comments = new List<string>(); // (<div></div>)

            while ((comment = Console.ReadLine()) != "end of comments")
            {
                comments.Add(comment);
            }

            Console.WriteLine("<h1>");
            Console.WriteLine(articleName);
            Console.WriteLine("</h1>");
            Console.WriteLine("<article>");
            Console.WriteLine(content);
            Console.WriteLine("</article>");

            foreach (var item in comments)
            {
                Console.WriteLine("<div>");
                Console.WriteLine(item);
                Console.WriteLine("</div>");
            }
        }
    }
}
