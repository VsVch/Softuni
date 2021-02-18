using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {       

        public Library(params Book[] books)
        {
            this.Books = books.ToList();
        }

        public List<Book> Books { get; set; }
        public IEnumerator<Book> GetEnumerator()
        {
            return new Libraryiterator(Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private class Libraryiterator : IEnumerator<Book>
        {
            private int index = -1;
            public Libraryiterator(List<Book> books)
            {
                Books = books;
            }
            public List<Book> Books { get; set; }
            public Book Current => Books[index];

            object IEnumerator.Current => Books[index];

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                return ++index < Books.Count;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }
}
