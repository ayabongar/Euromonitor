using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using EuromonitorApi.Db;
using EuromonitorApi.Models;

namespace EuromonitorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Database _database;

        public UserController(Database database)
        {
            _database = database;
        }


        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            //var users = _database.ExecuteStoredProcedure("usp_User_SelectAll");
            //return Ok(users);

            try
            {
                var dataTable = _database.ExecuteStoredProcedure("usp_User_SelectAll");
                var users = _database.ConvertDataTable<User>(dataTable); 
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest("Database connection error: " + ex.Message);
            }
        }



        [HttpPost("add")]
        public IActionResult AddUser([FromBody] User user)
        {
            try
            {              
                var parameters = new[]
                {
            new SqlParameter("@Email", user.Email),
            new SqlParameter("@FirstName", user.FirstName),
            new SqlParameter("@LastName", user.LastName)
        };

                // Execute the stored procedure and get the new User ID
                var dataTable = _database.ExecuteStoredProcedure("usp_User_Insert", parameters);

                // Extract the new User ID from the DataTable, assuming it's returned in the first row, first column
                int newUserId = Convert.ToInt32(dataTable.Rows[0][0]);

                // Return a response with the new user ID or a success message
                return Ok(new { Message = "User added successfully", UserId = newUserId });
            }
            catch (Exception ex)
            {
                // Return a detailed error message in case of failure
                return BadRequest("Error adding user: " + ex.Message);
            }
        }



        [HttpGet("test-connection")]
        public IActionResult TestConnection()
        {
            try
            {
                var dataTable = _database.ExecuteStoredProcedure("usp_User_SelectAll");
                var users = _database.ConvertDataTable<User>(dataTable); // Convert to List<User>
                return Ok(users); // Returns users if connection is successful
            }
            catch (Exception ex)
            {
                return BadRequest("Database connection error: " + ex.Message);
            }
        }

    }
}
