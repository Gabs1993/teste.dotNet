using BookTheos.Application.DTOs.UsersDTO;
using BookTheos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookTheos.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {
            var token = _tokenService.Login(loginDTO.Email, loginDTO.PassWord);

            if (token == null)
            {
                return Unauthorized("Invalid email or password");
            }

            return Ok(new { token });
        }
    }
}
