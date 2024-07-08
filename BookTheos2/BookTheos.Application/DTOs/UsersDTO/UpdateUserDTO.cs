using System.ComponentModel.DataAnnotations;


namespace BookTheos.Application.DTOs.Users
{
    public class UpdateUserDTO
    {
        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "O Email não é válido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "The PassWord field is required.")]
        [MinLength(6, ErrorMessage = "The password must be at least 6 characters long.")]
        public string? PassWord { get; set; }
        [Required(ErrorMessage = "The Role field is required")]
        public string? Role { get; set; }
    }
}
