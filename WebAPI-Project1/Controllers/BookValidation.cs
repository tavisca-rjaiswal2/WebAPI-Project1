using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebAPI_Project1.Controllers.Model;

namespace WebAPI_Project1.Controllers
{
    public class BookValidation
    {
        public List<string> Post(Book book)
        {
            List<string> errorList = new List<string>();
            Regex r = new Regex("^[a-zA-Z\\s]+$");

            if (book.id < 0)
                errorList.Add("Invalid Request, Id should not be negative");
            if (!r.IsMatch(book.name))
                errorList.Add("Invalid Request, Name should contain only alphabets");
            if (!r.IsMatch(book.category))
                errorList.Add("Invalid Request, Category should contain only alphabets");
            if (book.price < 0)
                errorList.Add("Invalid Request, Price should not be negative");
            if (!r.IsMatch(book.author))
                errorList.Add("Invalid Request, Author should contain only alphabets");
            return errorList;
        }
        public List<string> Put(Book book)
        {
            List<string> errorList = new List<string>();
            Regex r = new Regex("^[a-zA-Z\\s]+$");

            if (!r.IsMatch(book.name))
                errorList.Add("Invalid Request, Name should contain only alphabets");
            if (!r.IsMatch(book.category))
                errorList.Add("Invalid Request, Category should contain only alphabets");
            if (book.price < 0)
                errorList.Add("Invalid Request, Price should not be negative");
            if (!r.IsMatch(book.author))
                errorList.Add("Invalid Request, Author should contain only alphabets");
            return errorList;
        }
    }
}
