using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp7.Model
{
    public class BookCollection
    {
        private Book[] books =
        {
            new Book
            {
                Title = "Call of the wild, The",
                Author = "Jack London"
            },
            new Book
            {
                Title = "Tale of Two Cities, A",
                Author = "Charles Dickens"
            },
        };

        private Book nobook = null;

        public ref Book GetBookByTitle(string title)
        {
            for (int ctr = 0; ctr < books.Length; ctr++)
            {
                if (title==books[ctr].Title)
                {
                    return ref books[ctr];
                }
            }
            return ref nobook;
        }

        public void ListBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title},by{book.Author}");
            }
            Console.WriteLine();
        }
    }
}
