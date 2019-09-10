using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebAPI_Project1.Controllers.Model;
using FluentValidation;

namespace WebAPI_Project1.Controllers
{
    public class BookValidation:AbstractValidator<Book>
    {
        public BookValidation()
        {
            Regex r = new Regex("^[a-zA-Z\\s]+$");

            RuleSet("Id", () =>
            {
                RuleFor(book => book.id).NotEmpty().DependentRules(()=>
                {
                    RuleFor(book => book.id).GreaterThan(-1);
                });
            });

            RuleFor(book => book.name).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().Must(b => r.IsMatch(b)).WithMessage("Name must be string");

            RuleFor(book => book.category).NotEmpty().DependentRules(()=>
            {
                RuleFor(book => book.category).Must(b => r.IsMatch(b)).WithMessage("Category must be string");
            });

            RuleFor(book => book.price).NotEmpty();

            RuleFor(book => book.author).NotEmpty().DependentRules(() =>
            {
                RuleFor(book => book.author).Must(b => r.IsMatch(b)).WithMessage("Author must be string");
            });
        }
    }
}
