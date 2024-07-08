using BookTheos.Application.DTOs.Users;


namespace BookTheos.Application.Interfaces
{
    public interface IUserService
    {
        Task<ReadUserDTO> CreateUserAsync(CreateUserDTO userDTO);

        Task<ReadUserDTO> GetUserByIdAsync(Guid id);

        Task<List<ReadUserDTO>> GetAllUsersAsync();

        Task DeleteUserAsync(Guid id);

        Task<ReadUserDTO> UpdateUserAsync(Guid id, UpdateUserDTO userDTO);
    }
}
