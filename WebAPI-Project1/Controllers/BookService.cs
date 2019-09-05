using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Project1.Controllers.Model;
using Newtonsoft.Json.Linq;

namespace WebAPI_Project1.Controllers
{
    public class BookService
    {
        BookData bookData = new BookData();
        BookValidation bookValidation = new BookValidation();
        public IEnumerable<Book> Get()
        {
            return bookData.Get();
        }
        public Object Get(int id)
        {
            if (id < 0)
                return "Invalid Request, Id should not be negative";
            Book data = bookData.Get(id);
            if (data==null)
                return "Invalid Request, Book with given Id not found";
            return data;
        }
        public Object Post(Book book)
        {
            Validation validation = bookValidation.Post(book);
            if ((validation.isValid) == true)
                return bookData.Post(book);
            return validation.data;
        }
        public Object Put(int id, Book book)
        {
            if (id < 0)
                return "Invalid Request, Id should not be negative";
            Book data = bookData.Get(id);
            if (data==null)
                return "Invalid Request, Book with given Id not found";
            Validation validation = bookValidation.Put(book);
            if ((validation.isValid) == true)
                return bookData.Put(id, book);
            return validation.data;
        }
        public Object Delete(int id)
        {
            if (id < 0)
                return "Invalid Request, Id should not be negative";
            Book data = bookData.Get(id);
            if (data==null)
                return "Invalid Request, Book with given Id not found";
            return bookData.Delete(data);
        }

    }
}
