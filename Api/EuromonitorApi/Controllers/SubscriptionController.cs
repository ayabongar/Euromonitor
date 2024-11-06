using EuromonitorApi.Db;
using EuromonitorApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace EuromonitorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {     
        private readonly Database _database;

        public SubscriptionController(Database database)
        {
            _database = database;
        }

        [HttpPost("subscribe")]
        public IActionResult Subscribe([FromBody] Subscription subscription )
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@UserId", subscription.userId),
                    new SqlParameter("@BookId", subscription.bookId),                   
                 };

                var dataTable = _database.ExecuteStoredProcedure("usp_Subscription_Insert", parameters);
                int newSubscriptionId = Convert.ToInt32(dataTable.Rows[0][0]);

                return Ok("Subscribed to book successfully.");

            }
            catch (Exception ex)
            {
                return BadRequest("Error Subscribing: " + ex.Message);
            }            
        }

        [HttpPost("unsubscribe")]
        public IActionResult Unsubscribe([FromBody] Subscription subscription)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@UserId", subscription.userId),
                    new SqlParameter("@BookId", subscription.bookId)
                 };

                var dataTable = _database.ExecuteStoredProcedure("usp_Subscription_Delete", parameters);
                int delId = Convert.ToInt32(dataTable.Rows[1][0]);

                return Ok(new { deleted = true });
            }
            catch (Exception ex)
            {
                return BadRequest("Error unsubscribing: " + ex.Message);
            }
        }


        [HttpGet("{userId}")]
        public IActionResult GetUserSubscriptions([FromBody] Subscription subscription)
        {
            try
            {
                var parameters = new[] { new SqlParameter("@UserId", subscription.userId) };
   
                var dataTable = _database.ExecuteStoredProcedure("usp_User_SelectAll", parameters);
                var subscriptions = _database.ConvertDataTable<Subscription>(dataTable);
                return Ok(subscriptions);
            }
            catch (Exception ex)
            {
                return BadRequest("Error fetching subscriptions: " + ex.Message);
            }
        }

    }
}
