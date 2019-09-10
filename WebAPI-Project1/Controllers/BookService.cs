using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Project1.Controllers.Model;
using FluentValidation;
using FluentValidation.Results;

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
            ValidationResult result =bookValidation.Validate(book,ruleSet:"*");
            ResponseObject resObj = new ResponseObject();

            if (result.IsValid == true)
            {
                resObj.StatusCode = 201;
                resObj.data = bookData.Post(book);
            }
            else
            {
                resObj.StatusCode = 400;
                resObj.data = result.Errors;
            }
            return resObj;
        }
        public ResponseObject Put(int id, Book book)
        {
            ValidationResult result;
            ResponseObject resObj = new ResponseObject();
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
            else if(!(result = bookValidation.Validate(book)).IsValid)
            {
                resObj.StatusCode = 400;
                resObj.data = result.Errors;
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
                resObj.StatusCode = 204;
                bookData.Delete(data);
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
