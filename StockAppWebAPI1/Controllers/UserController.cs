using Microsoft.AspNetCore.Mvc;
using StockAppWebAPI11.Attributes;
using StockAppWebAPI11.Models;
using StockAppWebAPI11.Services;
using StockAppWebAPI11.ViewModels;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace StockAppWebAPI11.Controllers
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

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel)
        {
            try
            {
                string jwtToken = await _userService.Login(loginViewModel);
                return Ok(new { jwtToken });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [JwtAuthorize]
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
        [JwtAuthorize]
        [HttpPost("GetUserByID")]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                User? user = await _userService.GetUserById(id);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [JwtAuthorize]
        [HttpPost("GetUserByUsername")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            try
            {
                User? user = await _userService.GetUserByUsername(username);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [JwtAuthorize]
        [HttpPost("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            try
            {
                User? user = await _userService.GetUserByEmail(email);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [JwtAuthorize]
        [HttpPut("UpdateUserById/{id}")]
        public async Task<IActionResult> UpdateUserById(int id, User newUser)
        {
            try
            {
                User? user = await _userService.UpdateUserById(id, newUser);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [JwtAuthorize]
        [HttpDelete("DeleteUserById/{id}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            try
            {
                User? removeUser = await _userService.DeleteUserById(id);
                return Ok(removeUser);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
