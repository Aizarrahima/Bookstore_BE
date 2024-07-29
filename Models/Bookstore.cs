using Microsoft.EntityFrameworkCore;
using Bookstore.Models;

namespace AspNetCoreWebAPI8.Models
{
    public class Bookstore:DbContext
    {
        public Bookstore(DbContextOptions<Bookstore> options) : base(options) 
        {
            
        }

        public DbSet<Book> Books { get; set; } = null!;
    }
}
