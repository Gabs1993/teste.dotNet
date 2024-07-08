using BookTheos.Domain.Entities;


namespace BookTheos.Domain.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Users user);
        bool VerifyPassword(string providedPassword, string hashedPassword);
        string Login(string email, string providedPassword);

    }
}
