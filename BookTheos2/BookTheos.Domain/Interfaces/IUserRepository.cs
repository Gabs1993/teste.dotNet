using BookTheos.Domain.Entities;


namespace BookTheos.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<Users> CreateUser(Users user);
        Task<Users> GetUserById(Guid id);
        Task DeleteUser(Guid id);
        Task<List<Users>> GetAllUsers();
        Task<Users> UpdateUser(Users user);
    }
}
