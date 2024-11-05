using System.ComponentModel.DataAnnotations;

namespace EuromonitorApi.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Text { get; set; }

        [Required]
        public decimal PurchasePrice { get; set; }
    }
}
