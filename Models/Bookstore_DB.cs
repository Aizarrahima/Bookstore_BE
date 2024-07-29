using Microsoft.EntityFrameworkCore;
using Bookstore.Models;

namespace Bookstore.Models
{
    public class Bookstore_DB:DbContext
    {
        public Bookstore_DB(DbContextOptions<Bookstore_DB> options) : base(options) 
        {
            
        }

        public DbSet<Book> Books { get; set; } = null!;
    }
}
