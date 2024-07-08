using System.ComponentModel.DataAnnotations;


namespace BookTheos.Domain.Entities
{
    public class Users
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email não é válido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo PassWord é obrigatório.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        public string? PassWord { get; set; }

        public string? Role { get; set; }
    }
}
