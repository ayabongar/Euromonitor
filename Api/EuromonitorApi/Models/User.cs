using System.ComponentModel.DataAnnotations;

namespace EuromonitorApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}