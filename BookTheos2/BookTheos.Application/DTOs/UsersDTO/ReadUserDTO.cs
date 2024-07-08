
namespace BookTheos.Application.DTOs.Users
{
    public class ReadUserDTO
    {
        public Guid Id { get; set; }

        public string? Email { get; set; }

        public string? PassWord { get; set; }

        public string? Role { get; set; }
    }
}
