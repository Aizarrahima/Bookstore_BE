using Microsoft.EntityFrameworkCore;
using Bookstore.Models;

namespace Bookstore.Models
{
    public class Bookstore_DB:DbContext
    {
        public Bookstore_DB(DbContextOptions<Bookstore_DB> options) : base(options) 
        {
            // Enable Lazy Loading
            this.ChangeTracker.LazyLoadingEnabled = true;
        }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
    }
}
