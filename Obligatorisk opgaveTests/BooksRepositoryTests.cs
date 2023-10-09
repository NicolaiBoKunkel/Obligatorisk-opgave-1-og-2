using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorisk_opgave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Obligatorisk_opgave.BooksRepository;

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
            _booksRepository.Add(new Book { Id = 50, Title = "Book 5", Price = 8.95 });
        }

        [TestMethod()]
        public void GetTestFilterByPrice()
        {
            var result = _booksRepository.Get(byPrice: 8.95);

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.All(b => b.Price == 8.95));
        }
        [TestMethod()]
        public void GetTestSortByTitle()
        {
            var result = _booksRepository.Get(sort: SortBy.Title);

            Assert.AreEqual(5, result.Count);
            Assert.IsTrue(result.SequenceEqual(_booksRepository.Get().OrderBy(b => b.Title)));

        }
        [TestMethod()]
        public void GetTestSortByPrice()
        {
            var result = _booksRepository.Get(sort: SortBy.Price);

            Assert.AreEqual(5, result.Count); 
            Assert.IsTrue(result.SequenceEqual(_booksRepository.Get().OrderBy(b => b.Price)));
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


            Book? book = _booksRepository.Delete(10);
            Assert.IsNotNull(book);
            Assert.AreEqual("Book 1", book.Title);

            Book? book2 = _booksRepository.Delete(book.Id);
            Assert.IsNull(book2);

        }

        [TestMethod()]
        public void UpdateTest()
        {

            Book? book = _booksRepository.Update(10, new Book { Title = "Sjov Bog", Price = 20 });
            Assert.IsNotNull(book);
            Book? book2 = _booksRepository.GetById(10);
            Assert.AreEqual("Sjov Bog", book2.Title);

            Assert.IsNull(
                _booksRepository.Update(-1, new Book { Title = "Sjov Bog", Price = 9.99 }));
            Assert.ThrowsException<ArgumentException>(
                () => _booksRepository.Update(10, new Book { Title = "x", Price = 9 }));

        }
    }
}