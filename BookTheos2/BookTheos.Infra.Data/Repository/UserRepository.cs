using BookTheos.Domain.Entities;
using BookTheos.Domain.Interfaces;
using BookTheos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace BookTheos.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BookContext _context;

        public UserRepository(BookContext context)
        {
            _context = context;
        }

        public async Task<Users> CreateUser(Users user)
        {
            if (user.PassWord != null)
            {
                user.PassWord = BCrypt.Net.BCrypt.HashPassword(user.PassWord);
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(Guid id)
        {
            var book = await _context.Users.FindAsync(id);
            if (book != null)
            {
                _context.Users.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users?> GetUserById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<Users> UpdateUser(Users user)
        {
            if (user.PassWord != null)
            {
                user.PassWord = BCrypt.Net.BCrypt.HashPassword(user.PassWord);
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
