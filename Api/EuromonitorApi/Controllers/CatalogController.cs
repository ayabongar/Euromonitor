using Microsoft.AspNetCore.Mvc;
using EuromonitorApi.Models;
using System.Collections.Generic;

namespace EuromonitorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private static readonly List<Book> Books = new List<Book>();

        [HttpPost("add")]
        public IActionResult AddBook(Book book)
        {
            if (book == null) return BadRequest("Book data is required.");
            Books.Add(book);
            return Ok("Book added successfully.");
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(Books);
        }
    }
}
