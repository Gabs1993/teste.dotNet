using BookTheos.Application.DTOs.BookDTO;
using BookTheos.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookTheos.Web.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _services;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookServices services, ILogger<BookController> logger)
        {
            _services = services;
            _logger = logger;
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> AddBook(CreateBookDTO bookDTO)
        {
            _logger.LogInformation("Starting AddBook method");
            var book = await _services.AddBookAsync(bookDTO);
            _logger.LogInformation("Book added with ID {BookId}", book.Id);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            _logger.LogInformation("Starting GetBookById method with ID {BookId}", id);
            var book = await _services.GetBookByIdAsync(id);
            if (book == null)
            {
                _logger.LogWarning("Book with ID {BookId} not found", id);
                return NotFound();
            }
            _logger.LogInformation("Book with ID {BookId} retrieved", id);
            return Ok(book);
        }

        [HttpGet("ByName")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> GetBookByName(string name)
        {
            _logger.LogInformation("Starting GetBookByName method with Name {BookName}", name);
            var book = await _services.GetBookByNameAsync(name);
            if (book == null)
            {
                _logger.LogWarning("Book with Name {BookName} not found", name);
                return NotFound();
            }
            _logger.LogInformation("Book with Name {BookName} retrieved", name);
            return Ok(book);
        }

        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> GetAllBooks()
        {
            _logger.LogInformation("Starting GetAllBooks method");
            var books = await _services.GetAllBooksAsync();
            _logger.LogInformation("All books retrieved, count: {BooksCount}", books.Count());
            return Ok(books);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            _logger.LogInformation("Starting DeleteBook method with ID {BookId}", id);
            try
            {
                await _services.DeleteBookAsync(id);
                _logger.LogInformation("Book with ID {BookId} deleted", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting book with ID {BookId}", id);
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> UpdateBook(Guid id, UpdateBookDTO bookDTO)
        {
            _logger.LogInformation("Starting UpdateBook method with ID {BookId}", id);
            try
            {
                var updatedBook = await _services.UpdateBookAsync(id, bookDTO);
                if (updatedBook == null)
                {
                    _logger.LogWarning("Book with ID {BookId} not found", id);
                    return NotFound();
                }
                _logger.LogInformation("Book with ID {BookId} updated", id);
                return Ok(updatedBook);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating book with ID {BookId}", id);
                return NotFound(ex.Message);
            }
        }


    }
}
