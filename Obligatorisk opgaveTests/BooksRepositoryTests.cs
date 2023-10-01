using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorisk_opgave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opgave.Tests
{
    [TestClass()]
    public class BooksRepositoryTests
    {

        private BooksRepository _booksRepository = new();

        [TestInitialize]
        public void init()
        {
            _booksRepository = new();
            _booksRepository.Add(new Book { Id = 10, Title = "Book 1", Price = 10.99 });
            _booksRepository.Add(new Book { Id = 20, Title = "Book 2", Price = 15.49 });
            _booksRepository.Add(new Book { Id = 30, Title = "Book 3", Price = 12.99 });
            _booksRepository.Add(new Book { Id = 40, Title = "Book 4", Price = 8.95 });
            _booksRepository.Add(new Book { Id = 50, Title = "Book 5", Price = 19.99 });
        }

        [TestMethod()]
        public void GetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetByIdTest()
        {

            Assert.IsNotNull(_booksRepository.GetById(10));
            Assert.IsNull(_booksRepository.GetById(100));

        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {

            Book b = _booksRepository.Add(new Book { Id = 1, Title = "Romance Book", Price = 39.99 });
            Book? book = _booksRepository.Delete(b.Id);
            Assert.IsNotNull(book);
            Assert.AreEqual("Romance Book", book.Title);

            Book? book2 = _booksRepository.Delete(book.Id);
            Assert.IsNull(book2);

        }

        [TestMethod()]
        public void UpdateTest()
        {

            Book b = _booksRepository.Add(new Book { Id = 2, Title = "Eventyr Bog", Price = 49.95 });
            Book? book = _booksRepository.Update(b.Id, new Book { Title = "Sjov Bog", Price = 20 });
            Assert.IsNotNull(book);
            Book? book2 = _booksRepository.GetById(b.Id);
            Assert.AreEqual("Eventyr Bog", book.Title);

            Assert.IsNull(
                _booksRepository.Update(-1, new Book { Title = "Gammel Bog", Price = 9.99 }));
            Assert.ThrowsException<ArgumentException>(
                () => _booksRepository.Update(b.Id, new Book { Title = "", Price = 9 }));

        }
    }
}