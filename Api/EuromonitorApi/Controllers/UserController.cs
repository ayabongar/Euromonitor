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
                
                var dataTable = _database.ExecuteStoredProcedure("usp_User_Insert", parameters);               
                int newUserId = Convert.ToInt32(dataTable.Rows[0][0]);              
                return Ok(new { Message = "User added successfully", UserId = newUserId });
            }
            catch (Exception ex)
            {               
                return BadRequest("Error adding user: " + ex.Message);
            }
        }

        //[HttpGet("test-connection")]
        //public IActionResult TestConnection()
        //{
        //    try
        //    {
        //        var dataTable = _database.ExecuteStoredProcedure("usp_User_SelectAll");
        //        var users = _database.ConvertDataTable<User>(dataTable); 
        //        return Ok(users); 
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Database connection error: " + ex.Message);
        //    }
        //}

    }
}
