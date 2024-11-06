using Microsoft.AspNetCore.Mvc;
using EuromonitorApi.Models;
using System.Collections.Generic;
using EuromonitorApi.Db;
using System.Data.SqlClient;

namespace EuromonitorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
       // private static readonly List<Book> Books = new List<Book>();

        private readonly Database _database;

        public CatalogController(Database database)
        {
            _database = database;
        }



        [HttpGet("all")]
        public IActionResult GetBooks()
        {
            try
            {
                var dataTable = _database.ExecuteStoredProcedure("usp_Book_SelectAll");
                var books = _database.ConvertDataTable<Book>(dataTable);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest("Database connection error: " + ex.Message);
            }
        }




        [HttpPost("add")]
        public IActionResult AddBook([FromBody] Book book)
        {
            if (book == null) return BadRequest("Book data is required.");

            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@Name", book.Name),
                    new SqlParameter("@Text", book.Text),
                    new SqlParameter("@PurchasePrice", book.PurchasePrice)
                };

                var dataTable = _database.ExecuteStoredProcedure("usp_Book_Insert", parameters);
              
                int newBookId = Convert.ToInt32(dataTable.Rows[0]["BookId"]);
                return Ok(new { Message = "Book added successfully", BookId = newBookId });
            }
            catch (Exception ex)
            {
                return BadRequest("Error adding book: " + ex.Message);
            }
        }



        //public IActionResult GetBooks()
        //{
        //    return Ok(Books);
        //}
    }
}
