using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opgave
{
    public class BooksRepository
    {
        //OPGAVE 2

        private readonly List<Book> _book = new List<Book>();

        public enum SortBy { Title, Price}



        public List<Book> Get(double? byPrice = null, SortBy? sort = null)
        {

            List<Book> result = new(_book);
            if (byPrice != null)
            {
                result = result.Where(b => b.Price == byPrice).ToList();
            }
            if (sort != null)
            {
                switch (sort) { 
                    case SortBy.Title:
                        result = result.OrderBy(b => b.Title).ToList();
                        break;
                    case SortBy.Price:
                        result = result.OrderBy(b => b.Price).ToList();
                        break;
                }
            }

            return result;
        }

        public Book? GetById(int id)
        {
            return _book.Find(book => book.Id == id);
        }

        public Book Add(Book book)
        {
            _book.Add(book);
            return book;
        }

        public Book? Delete(int id)
        {
            Book? book = GetById(id);
            if (book == null)
            {
                return null;
            }
            _book.Remove(book);
            return book;
        }


        public Book? Update(int id, Book book)
        {
            book.Validate();
            Book? existingBook = GetById(id);
            if (existingBook == null)
            {
                return null;
            }
            existingBook.Title = book.Title;
            existingBook.Price = book.Price;
            return existingBook;
        }
    }
}
