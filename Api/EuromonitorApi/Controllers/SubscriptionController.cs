using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EuromonitorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private static readonly Dictionary<int, List<int>> UserSubscriptions = new Dictionary<int, List<int>>();

        [HttpPost("subscribe")]
        public IActionResult Subscribe(int userId, int bookId)
        {
            if (!UserSubscriptions.ContainsKey(userId))
                UserSubscriptions[userId] = new List<int>();

            UserSubscriptions[userId].Add(bookId);
            return Ok("Subscribed to book successfully.");
        }

        [HttpPost("unsubscribe")]
        public IActionResult Unsubscribe(int userId, int bookId)
        {
            if (UserSubscriptions.ContainsKey(userId) && UserSubscriptions[userId].Contains(bookId))
            {
                UserSubscriptions[userId].Remove(bookId);
                return Ok("Unsubscribed from book successfully.");
            }

            return NotFound("Subscription not found.");
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserSubscriptions(int userId)
        {
            if (UserSubscriptions.ContainsKey(userId))
                return Ok(UserSubscriptions[userId]);

            return NotFound("User has no subscriptions.");
        }
    }
}
