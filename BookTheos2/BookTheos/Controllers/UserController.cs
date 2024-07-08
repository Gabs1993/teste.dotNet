using BookTheos.Application.DTOs.Users;
using BookTheos.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookTheos.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _services;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService services, ILogger<UserController> logger)
        {
            _services = services;
            _logger = logger;   
        }

        [HttpPost]
        public async Task<IActionResult> AddUsers(CreateUserDTO userDTO)
        {
            _logger.LogInformation("Starting AddUsers method");
            var user = await _services.CreateUserAsync(userDTO);
            _logger.LogInformation("User added with ID {UserId}", user.Id);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            _logger.LogInformation("Starting GetUserById method with ID {UserId}", id);
            var user = await _services.GetUserByIdAsync(id);
            if (user == null)
            {
                _logger.LogWarning("User with ID {UserId} not found", id);
                return NotFound();
            }
            _logger.LogInformation("User with ID {UserId} retrieved", id);
            return Ok(user);
        }

        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> GetAllUsers()
        {
            _logger.LogInformation("Starting GetAllUsers method");
            var users = await _services.GetAllUsersAsync();
            _logger.LogInformation("All users retrieved, count: {UsersCount}", users.Count());
            return Ok(users);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            _logger.LogInformation("Starting DeleteUser method with ID {UserId}", id);
            try
            {
                await _services.DeleteUserAsync(id);
                _logger.LogInformation("User with ID {UserId} deleted", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting user with ID {UserId}", id);
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> UpdateUsers(Guid id, UpdateUserDTO userDTO)
        {
            _logger.LogInformation("Starting UpdateUsers method with ID {UserId}", id);
            try
            {
                var updateUser = await _services.UpdateUserAsync(id, userDTO);
                if (updateUser == null)
                {
                    _logger.LogWarning("User with ID {UserId} not found", id);
                    return NotFound();
                }
                _logger.LogInformation("User with ID {UserId} updated", id);
                return Ok(updateUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user with ID {UserId}", id);
                return BadRequest(ex.Message);
            }
        }


    }
}
