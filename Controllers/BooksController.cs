using Bookstore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly Bookstore_DB _bookstore;
        public BooksController(Bookstore_DB bookstore)
        {
            _bookstore = bookstore;
        }

        #region Get: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            if (_bookstore == null)
            {
                return NotFound();
            }
            return await _bookstore.Books.ToListAsync();
        }
        #endregion

        #region Get: api/Books/{Id}
        [HttpGet("{Id}")]
        public async Task<ActionResult<Book>> GetBook(int Id)
        {
            if (_bookstore.Books == null) { 
            return NotFound();
            }

            var book = await _bookstore.Books.FindAsync(Id);
            if (book is null) 
            {
                return NotFound();
            }
            return book;
        }
        #endregion

        #region Post: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            _bookstore.Books.Add(book);
            await _bookstore.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBook), new { Id = book.Id }, book);
        }
        #endregion

        #region Put: api/Books/{Id}
        [HttpPut]
        public async Task<ActionResult<Book>> BookUpdate(int Id, Book book)
        {
            if (Id != book.Id)
            {
                return BadRequest();
            }

            _bookstore.Entry(book).State = EntityState.Modified;
            try
            {
                await _bookstore.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool BookExists(int Id) {
            return (_bookstore.Books?.Any(book => book.Id == Id)).GetValueOrDefault();
        }
        #endregion

        #region Delete: api/Books/{Id}
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Book>> BookDelete(int Id)
        {
            if(_bookstore.Books is null)
            {
                return NotFound();
            }

            var book = await _bookstore.Books.FindAsync(Id);
            if(book is null)
            {
                return NotFound();
            }

            _bookstore.Books.Remove(book);
            await _bookstore.SaveChangesAsync();
            return NoContent();
        }
        #endregion
    }
}
