using BookTheos.Domain.Entities;
using BookTheos.Domain.Interfaces;
using BookTheos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace BookTheos.Infra.Data.Repository
{
    public class BookRepository : IBookReposity
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public async Task<Book> AddBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async  Task DeleteBook(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Book>> GetBookAll()
        {
            return await _context.Books.OrderBy(b => b.Name).ToListAsync();
        }

        public async Task<Book?> GetBookById(Guid id)
        {
            return await _context.Books.FindAsync(id);
        }

        public Task<Book?> GetBookByName(string name)
        {
            return _context.Books.FirstOrDefaultAsync(b => b.Name == name);
        }

        public async Task<Book> UpdateBook(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}
