using AutoMapper;
using BookTheos.Application.DTOs.Users;
using BookTheos.Domain.Entities;


namespace BookTheos.Application.Mappins
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<CreateUserDTO, Users>();
            CreateMap<UpdateUserDTO, Users>();
            CreateMap<ReadUserDTO, Users>();
            CreateMap<Users, ReadUserDTO>();
        }
    }
}
