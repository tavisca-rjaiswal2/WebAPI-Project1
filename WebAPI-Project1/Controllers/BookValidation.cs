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
        public Validation Post(Book book)
        {
            Validation validation = new Validation { isValid=false,data=null };
            Regex r = new Regex("^[a-zA-Z\\s]+$");

            if (book.id < 0)
                validation.data = "Invalid Request, Id should not be negative";
            else if (!r.IsMatch(book.name))
                validation.data = "Invalid Request, Name should contain only alphabets";
            else if (!r.IsMatch(book.category))
                validation.data = "Invalid Request, Category should contain only alphabets";
            else if (book.price < 0)
                validation.data = "Invalid Request, Price should not be negative";
            else if (!r.IsMatch(book.author))
                validation.data = "Invalid Request, Author should contain only alphabets";
            else
                validation.isValid = true;
            return validation;
        }
        public Validation Put(Book book)
        {
            Validation validation = new Validation { isValid = false, data = null };
            Regex r = new Regex("^[a-zA-Z\\s]+$");

            if (!r.IsMatch(book.name))
                validation.data = "Invalid Request, Name should contain only alphabets";
            else if (!r.IsMatch(book.category))
                validation.data = "Invalid Request, Category should contain only alphabets";
            else if (book.price < 0)
                validation.data = "Invalid Request, Price should not be negative";
            else if (!r.IsMatch(book.author))
                validation.data = "Invalid Request, Author should contain only alphabets";
            else
                validation.isValid = true;
            return validation;
        }
    }
}
