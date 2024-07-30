using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(100)]
        public string Categories { get; set; }
        [Required]
        [StringLength(100)]
        public string publisher { get; set; }
        public virtual Author Author { get; set; } // Lazy loading
    }
}
