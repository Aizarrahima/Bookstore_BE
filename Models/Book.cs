namespace Bookstore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Categories { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
