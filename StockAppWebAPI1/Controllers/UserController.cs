using Microsoft.AspNetCore.Mvc;
using StockAppWebAPI1.Models;
using StockAppWebAPI1.Services;
using StockAppWebAPI1.ViewModels;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace StockAppWebAPI1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            try
            {
                User? newUser = await _userService.Register(registerViewModel);
                return Ok(newUser);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("GetByID")]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                User? user = await _userService.GetById(id);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("GetByUsername")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            try
            {
                User? user = await _userService.GetByUsername(username);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("GetByEmail")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            try
            {
                User? user = await _userService.GetByEmail(email);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }



        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(int id, User newUser)
        {
            try
            {
                User? user = await _userService.UpdateById(id, newUser);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                User? removeUser = await _userService.DeleteById(id);
                return Ok(removeUser);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
