using Microsoft.AspNetCore.Mvc;
using StockAppWebAPI1.Models;
using StockAppWebAPI1.Services;

namespace StockAppWebAPI1.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                User? newUser = await _userService.Register(user);
                return Ok(newUser);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
