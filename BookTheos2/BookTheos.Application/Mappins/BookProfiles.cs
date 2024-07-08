using AutoMapper;
using BookTheos.Application.DTOs.BookDTO;
using BookTheos.Domain.Entities;


namespace BookTheos.Application.Profiles
{
    public class BookProfiles : Profile
    {
        public BookProfiles()
        {
            CreateMap<CreateBookDTO, Book>();
            CreateMap<UpdateBookDTO, Book>();
            CreateMap<ReadBookDTO, Book>();
            CreateMap<Book, ReadBookDTO>();
            
        }
    }
}
