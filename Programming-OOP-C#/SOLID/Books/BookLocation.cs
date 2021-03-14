using System;
using System.Collections.Generic;
using System.Text;

namespace Books
{
    public class BookLocation
    {
        public Book Book { get; set; }
        public int Location { get; set; }

        public int TurnPage(Book book)
        {
            Location ++;

            return Location;
        }
    }
}
