using AutoMapper;
using BookTheos.Application.DTOs.BookDTO;
using BookTheos.Application.Interfaces;
using BookTheos.Domain.Entities;
using BookTheos.Domain.Interfaces;

namespace BookTheos.Application.Services
{
    public class BookService : IBookServices
    {
        private readonly IBookReposity _repository;
        private readonly IMapper _mapper;

        public BookService(IBookReposity repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReadBookDTO> AddBookAsync(CreateBookDTO bookDTO)
        {
            var existingBook = await _repository.GetBookByName(bookDTO.Name);
            if (existingBook != null)
            {
                throw new Exception("This book cannot be registered as we already have this unit, try registering another book");
            }

            var book = _mapper.Map<Book>(bookDTO); 
            var addedBook = await _repository.AddBook(book);
            return _mapper.Map<ReadBookDTO>(addedBook);
        }

        public async Task DeleteBookAsync(Guid id)
        {
            await _repository.DeleteBook(id);
        }

        public async Task<List<ReadBookDTO>> GetAllBooksAsync()
        {
            var books = await _repository.GetBookAll();
            return _mapper.Map<List<ReadBookDTO>>(books);
        }

        public async Task<ReadBookDTO> GetBookByIdAsync(Guid id)
        {
            var book = await _repository.GetBookById(id);
            return _mapper.Map<ReadBookDTO>(book);
        }

        public async Task<ReadBookDTO> GetBookByNameAsync(string name)
        {
            var book = await _repository.GetBookByName(name);
            return _mapper.Map<ReadBookDTO>(book);
        }

        public async Task<ReadBookDTO> UpdateBookAsync(Guid id, UpdateBookDTO bookDTO)
        {
            
            var existingBook = await _repository.GetBookById(id);

            if (existingBook == null)
            {
                throw new KeyNotFoundException($"Book with id {id} not found.");
            }

            _mapper.Map(bookDTO, existingBook);
            var updatedBook = await _repository.UpdateBook(existingBook);
            return _mapper.Map<ReadBookDTO>(updatedBook);
        }

       


    }
}
