using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.SchoolLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> books = Console.ReadLine()
                                        .Split("&", StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();

            string input;

            while ((input = Console.ReadLine()) != "Done")
            {
                                

                string[] command = input.Split("|", StringSplitOptions.RemoveEmptyEntries).ToArray();

                 string cmdArg = command[0].TrimStart().TrimEnd(); 
                               
                switch (cmdArg)
                {
                    case "Add Book":
                        string book = command[1].TrimStart().TrimEnd(); ; 

                        if (books.Contains(book))
                        {
                            continue;
                        }
                        books.Insert(0, book);
                        break;

                    case "Take Book":
                        book =command[1].TrimStart().TrimEnd(); ;
                        books.Remove(book);
                        break;

                    case "Swap Books":
                        book = command[1].TrimStart().TrimEnd();
                        string newBook = command[2].TrimStart().TrimEnd(); 

                        if (!books.Contains(newBook) || !books.Contains( book))
                        {
                            continue;
                        }

                        string firstBook = string.Empty;
                        string secondBook = string.Empty;

                        for (int i = 0; i < books.Count; i++)
                        {

                            if (books[i] == book)
                            {
                                firstBook = books[i];

                                for (int j = 0; j < books.Count; j++)
                                {
                                    if (books[j] == newBook)
                                    {
                                        secondBook = books[j];
                                                                             
                                        books[i] = secondBook;
                                        books[j] = firstBook;
                                        break;
                                    }
                                }
                                break;
                            }                                                     
                        }             
                                               
                        break;

                    case "Insert Book":

                        book = command[1].TrimStart().TrimEnd(); 
                        books.Add(book);

                        break;

                    case "Check Book":

                        int index = int.Parse(command[1]);

                        if (index < 0 || index >= books.Count)
                        {
                            continue;
                        }
                        else
                        {
                            
                            Console.WriteLine(books[index]);
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", books));
        }
        
    }
}
