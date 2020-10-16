using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using RestBookService.Model;


namespace RestBookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<Book> bList = new List<Book>()
        {
            new Book("Snow White", "Grimms", 500, "1111111111111"),
            new Book("The Ugly Duckling", "Andersen", 600, "2222222222222"),
            new Book("Ratatouille", "Saxon", 750, "3333333333333"),
        };

        // GET: api/Book
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bList;
        }

        // GET: api/Book/5
        [HttpGet("{isbn13}", Name = "Get")]
        public IActionResult Get(string isbn13)
        {
            var book = GetBook(isbn13);
            if (book == null)
            {
                return NotFound(new { message = "Book not found" });
            }
            return Ok(book);
        }

        private object GetBook(string isbn13)
        {
            var book = bList.FirstOrDefault(e => e.Isbn13 == isbn13);
            return book;
        }


        // POST: api/Book
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (!BookExists(book.Isbn13))
            {
                bList.Add(book);
                return CreatedAtAction("Get", new { id = book.Isbn13 }, book);
            }
            else
            {
                return NotFound(new { message = "Isbn is duplicated" });
            }
        }

        private bool BookExists(object isbn13)
        {
            return bList.Any(e => e.Isbn13 == isbn13);
        }

        // PUT: api/Book/5
        [HttpPut("{isbn13}")]
        public IActionResult Put(string isbn13, [FromBody] Book newBook)
        {
            if (isbn13 != newBook.Isbn13)
            {
                return BadRequest();
            }
            var currentBook = GetBook(isbn13);

            if (currentBook != null)
            {
                currentBook.bList.Isbn13 = newBook.Isbn13;
                currentBook.bList.Author = newBook.Author;
                currentBook.bList.Title = newBook.Title;
                currentBook.bList.PageNumber = newBook.PageNumber;
            }
            else
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string isbn13)
        {
            var book = GetBook(isbn13);

            if (book != null)
            {
                bList.Remove(book);
            }
            else
            {
                return NotFound();
            }
            return Ok(book);
        }
    }
}
