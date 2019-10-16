using System;

namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();
            var cheaperBooks = books.FindAll(x => x.Price > 10); // Using LE

            foreach (var book in cheaperBooks)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
