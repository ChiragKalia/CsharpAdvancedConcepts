using System;
using System.Collections.Generic;
using System.Text;

namespace LambdaExpressions
{
    public class BookRepository
    {
        public List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book(){ Title = "Book 1", Price = 13},
                new Book(){ Title = "Book 2", Price = 19},
                new Book(){ Title = "Book 3", Price = 21}
            };
        }
    }
}
