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
    public class BookTests
    {

        private Book book = new Book { Id = 1, Title = "Story Book", Price = 100 };
        private Book nullTitleBook = new Book { Id = 2, Title = null, Price = 100 };
        private Book invalidTitleBook = new Book { Id = 3, Title = "no", Price = 100 };
        private Book invalidPriceBook = new Book { Id = 4, Title = "Romantic Book", Price = 10000 };



        [TestMethod()]
        public void ToStringTest()
        {
            string str = book.ToString();
            Assert.AreEqual("1, Story Book, 100", str);
        }

        [TestMethod()]
        public void ValidateTitleTest()
        {
            book.ValidateTitle();
            Assert.ThrowsException<ArgumentNullException>(() => nullTitleBook.ValidateTitle());
            Assert.ThrowsException<ArgumentException>(() => invalidTitleBook.ValidateTitle());
        }

        [TestMethod()]
        public void ValidatePriceTest()
        {
            book.ValidatePrice();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => invalidPriceBook.ValidatePrice());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            book.Validate();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => invalidPriceBook.Validate());
            Assert.ThrowsException<ArgumentNullException>(() => nullTitleBook.Validate());
            Assert.ThrowsException<ArgumentException>(() => invalidTitleBook.Validate());
        }
    }
}