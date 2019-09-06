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
        public ResponseObject Get(int id)
        {
            ResponseObject resObj = new ResponseObject();
            Book data;
            
            if (id < 0)
            {
                resObj.StatusCode = 400;
                resObj.data = "Invalid Request, Id should not be negative";
            }
            else if ((data=bookData.Get(id)) != null)
            {
                resObj.StatusCode = 200;
                resObj.data = data;
            }
            else
            {
                resObj.StatusCode = 404;
                resObj.data = "Invalid Request, Book with given Id not found";
            }

            return resObj;
        }
        public ResponseObject Post(Book book)
        {
            ResponseObject resObj = new ResponseObject();
            List<string> errorList = bookValidation.Post(book);
            if ( errorList.Count== 0)
            {
                resObj.StatusCode = 201;
                resObj.data = bookData.Post(book);
            }
            else
            {
                resObj.StatusCode = 400;
                resObj.data = errorList;
            }
            return resObj;
        }
        public ResponseObject Put(int id, Book book)
        {
            ResponseObject resObj = new ResponseObject();
            List<string> errorList;
            if (id < 0)
                {
                resObj.StatusCode = 400;
                resObj.data = "Invalid Request, Id should not be negative";
            }
            else if (bookData.Get(id) == null)
            {
                resObj.StatusCode = 404;
                resObj.data = "Invalid Request, Book with given Id not found";
            }
            else if((errorList = bookValidation.Put(book)).Count>0)
            {
                resObj.StatusCode = 400;
                resObj.data = errorList;
            }
            else
            {
                resObj.StatusCode = 200;
                resObj.data = bookData.Put(id, book);
            }
            return resObj;
        }
        public ResponseObject Delete(int id)
        {
            ResponseObject resObj = new ResponseObject();
            Book data;

            if (id < 0)
            {
                resObj.StatusCode = 400;
                resObj.data = "Invalid Request, Id should not be negative";
            }
            else if ((data = bookData.Get(id)) != null)
            {
                resObj.StatusCode = 200;
                resObj.data = bookData.Delete(data);
            }
            else
            {
                resObj.StatusCode = 404;
                resObj.data = "Invalid Request, Book with given Id not found";
            }

            return resObj;
        }
    }
}
