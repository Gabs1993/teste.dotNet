using BookTheos.Application.DTOs.BookDTO;


namespace BookTheos.Application.Interfaces
{
    public interface IBookServices
    {
        Task<ReadBookDTO> AddBookAsync(CreateBookDTO bookDTO);

        Task<ReadBookDTO> GetBookByIdAsync(Guid id);

        Task<List<ReadBookDTO>> GetAllBooksAsync();

        Task DeleteBookAsync(Guid id);

        Task<ReadBookDTO> UpdateBookAsync(Guid id, UpdateBookDTO bookDTO);

        Task<ReadBookDTO> GetBookByNameAsync(string name);
    }
}
