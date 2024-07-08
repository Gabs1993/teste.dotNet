using AutoMapper;
using BookTheos.Application.DTOs.Users;
using BookTheos.Application.Interfaces;
using BookTheos.Domain.Entities;
using BookTheos.Domain.Interfaces;


namespace BookTheos.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ReadUserDTO> CreateUserAsync(CreateUserDTO userDTO)
        {
            var user = _mapper.Map<Users>(userDTO);
            var users = await _repository.CreateUser(user);
            return _mapper.Map<ReadUserDTO>(users);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await _repository.DeleteUser(id);
        }

        public async Task<List<ReadUserDTO>> GetAllUsersAsync()
        {
            var users = await _repository.GetAllUsers();
            return _mapper.Map<List<ReadUserDTO>>(users);
        }

        public async Task<ReadUserDTO> GetUserByIdAsync(Guid id)
        {
            var user = await _repository.GetUserById(id);
            return _mapper.Map<ReadUserDTO>(user);
        }

        public async Task<ReadUserDTO> UpdateUserAsync(Guid id, UpdateUserDTO userDTO)
        {
            var existingUsers = await _repository.GetUserById(id);

            if (existingUsers == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found.");
            }

            _mapper.Map(userDTO, existingUsers);
            var updateUsers = await _repository.UpdateUser(existingUsers);
            return _mapper.Map<ReadUserDTO>(updateUsers);
        }
    }
}
