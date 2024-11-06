using System.ComponentModel.DataAnnotations;

namespace EuromonitorApi.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int userId { get; set; }

        public int bookId { get; set; }
    }
}
