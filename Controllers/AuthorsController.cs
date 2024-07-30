using Bookstore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly Bookstore_DB _bookstore;

        public AuthorsController(Bookstore_DB bookstore)
        {
            _bookstore = bookstore;
        }

        #region Get: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            if (_bookstore.Authors == null)
            {
                return NotFound();
            }

            return await _bookstore.Authors.ToListAsync();
        }
        #endregion

        #region Get: api/Authors/{Id}
        [HttpGet("{Id}")]
        public async Task<ActionResult<Author>> GetAuthor(int Id)
        {
            if (_bookstore.Authors == null)
            {
                return NotFound();
            }

            var author = await _bookstore.Authors.FindAsync(Id);

            if (author == null)
            {
                return NotFound();
            }
            return author;
        }
        #endregion

        #region Post: api/Authors
        [HttpPost]
        public async Task<ActionResult<Author>> CreateAuthor(Author author)
        {
            _bookstore.Authors.Add(author);
            await _bookstore.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAuthor), new { Id = author.Id }, author);
        }
        #endregion

        #region Put: api/Authors/{Id}
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateAuthor(int Id, Author author)
        {
            if (Id != author.Id)
            {
                return BadRequest();
            }

            _bookstore.Entry(author).State = EntityState.Modified;
            try
            {
                await _bookstore.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var updatedAuthor = await _bookstore.Authors.FindAsync(Id);

            return Ok(updatedAuthor);
        }

        private bool AuthorExists(int Id)
        {
            return (_bookstore.Authors?.Any(author => author.Id == Id)).GetValueOrDefault();
        }
        #endregion

        #region Delete: api/Authors/{Id}
        [HttpDelete("{Id}")]
        public async Task<IActionResult> AuthorDelete(int Id)
        {
            if (_bookstore.Authors == null)
            {
                return NotFound();
            }

            var author = await _bookstore.Authors.FindAsync(Id);
            if (author == null)
            {
                return NotFound();
            }

            _bookstore.Authors.Remove(author);
            await _bookstore.SaveChangesAsync();
            return Ok(new { message = "Delete success." });
        }
        #endregion
    }
}
