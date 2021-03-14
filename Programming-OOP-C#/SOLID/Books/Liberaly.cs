using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books
{
    public class Liberaly
    {
        private List<BookLocation> bookLocations;

        public Liberaly()
        {
            bookLocations = new List<BookLocation>();
        }

        public void AddBook(Book book) 
        {
            bookLocations.Add(new BookLocation() { Book = book, Location = 0 });        
        }

        public int TurnPage(Book book)
        {
            BookLocation bookLocation = this.bookLocations.First(b => b.Book == book);
            

            return bookLocation.TurnPage(book);        
        }
    }
}
