using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Project1.Controllers.Model;

namespace WebAPI_Project1.Controllers
{
    public class BookData
    {
        static List<Book> bookList = new List<Book>();
        public IEnumerable<Book> Get()
        {
            return bookList;
        }
        public Book Get(int id)
        {
            var data=bookList.Find(b => b.id == id);
            return data;
        }
        public Book Post(Book obj)
        {
            bookList.Add(obj);
            return obj;
        }
        public Book Put(int id,Book book)
        {
            bookList.Where(b => b.id == id)
                .Select(b => {
                    b.name = book.name;
                    b.category = book.category;
                    b.price=book.price;
                    b.author = book.author;
                    return b; })
                .ToList();
            return bookList.Find(b => b.id == id);
        }
        public bool Delete(Book book)
        {
            bookList.Remove(book);
            return true;
        }

    }
}
