using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI_Project1.Controllers;
using WebAPI_Project1.Controllers.Model;
using Xunit;

namespace WebAPI_Project1Test
{
    public class BookDataTest
    {
        [Fact]
        public void Get_Should_Return_Empty_Array_When_Book_Not_Added()
        {
            BookData bookData = new BookData();
            var actual=bookData.Get();
            Assert.Empty(actual);
        }
        [Fact]
        public void Get_Should_Return_Array_Of_Books_When_Books_Are_Added()
        {
            Book book = new Book {
                id = 1,
                name="abc",
                category="def",
                price=200,
                author="ghi"
            };
            List<Book> list = new List<Book>();
            list.Add(book);
            BookData bookData = new BookData();
            bookData.Post(book);
            IEnumerable<Book> actual = bookData.Get();
            Assert.NotEmpty(actual);
        }
        [Fact]
        public void Get_Should_Return_A_Book_When_BookId_Is_Passed()
        {
            Book book = new Book
            {
                id = 2,
                name = "abc",
                category = "def",
                price = 200,
                author = "ghi"
            };
            BookData bookData = new BookData();
            bookData.Post(book);
            var actual = bookData.Get(2);
            Assert.Equal(book, actual);
        }
        [Fact]
        public void Post_Should_Return_A_Book_When_Book_Is_Added()
        {
            Book book = new Book
            {
                id = 3,
                name = "abc",
                category = "def",
                price = 200,
                author = "ghi"
            };
            BookData bookData = new BookData();
            var actual = bookData.Post(book);            
            Assert.Equal(book, actual);
        }
        [Fact]
        public void Put_Should_Return_A_Book_When_Book_Is_Updated()
        {
            Book book = new Book
            {
                id = 3,
                name = "abc",
                category = "def",
                price = 200,
                author = "ghi"
            };
            BookData bookData = new BookData();
            bookData.Post(book);
            book.name = "abcd";
            var actual = bookData.Put(3,book);
            Assert.Equal(book, actual);
        }
        [Fact]
        public void Delete_Should_Return_True_When_Book_Is_Deleted()
        {
            Book book = new Book
            {
                id = 4,
                name = "abc",
                category = "def",
                price = 200,
                author = "ghi"
            };
            BookData bookData = new BookData();
            bookData.Post(book);
            var actual = bookData.Delete(book);
            Assert.Equal(true, actual);
        }
    }
}
