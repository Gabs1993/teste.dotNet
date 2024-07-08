using BookTheos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookTheos.Infra.Data.Context
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
