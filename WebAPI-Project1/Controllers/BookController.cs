using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Project1.Controllers.Model;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_Project1.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        BookService bookService = new BookService();
        public BookController()
        {
        }
        // GET: api/values
        [HttpGet]
        public Object Get()
        {
            return bookService.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Object Get(int id)
        {
            return bookService.Get(id);
        }

        // POST api/values
        [HttpPost]
        public Object Post([FromBody]Book book)
        {
            return bookService.Post(book);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Object Put(int id, [FromBody]Book book)
        {
            return bookService.Put(id, book);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Object Delete(int id)
        {
            return bookService.Delete(id);
        }
    }
}
