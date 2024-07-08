using BookTheos.Domain.Entities;


namespace BookTheos.Domain.Interfaces
{
    public interface IBookReposity
    {
        Task<Book> AddBook(Book book);
        Task<Book> GetBookById(Guid id);
        Task<List<Book>> GetBookAll();
        Task DeleteBook(Guid id);
        Task<Book> UpdateBook(Book book);
        Task<Book> GetBookByName(string name);

    }
}
