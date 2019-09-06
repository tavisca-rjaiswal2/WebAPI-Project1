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
            ResponseObject resObj = bookService.Get(id);
            return StatusCode(resObj.StatusCode,resObj.data);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody]Book book)
        {
            ResponseObject resObj = bookService.Post(book);
            return StatusCode(resObj.StatusCode, resObj.data);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Object Put(int id, [FromBody]Book book)
        {
            ResponseObject resObj = bookService.Put(id,book);
            return StatusCode(resObj.StatusCode, resObj.data);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Object Delete(int id)
        {
            ResponseObject resObj = bookService.Delete(id);
            return StatusCode(resObj.StatusCode, resObj.data);
        }
    }
}
