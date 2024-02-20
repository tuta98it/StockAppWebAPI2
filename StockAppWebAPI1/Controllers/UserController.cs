using Microsoft.AspNetCore.Mvc;
using StockAppWebAPI1.Attributes;
using StockAppWebAPI1.Models;
using StockAppWebAPI1.Services;
using StockAppWebAPI1.ViewModels;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace StockAppWebAPI1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WatchlistController : ControllerBase
    {
        private readonly IUserService _userService;
        public WatchlistController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel)
        {
            string jwtToken = await _userService.Login(loginViewModel);
            return Ok(new { jwtToken });
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
        [JwtAuthorize]
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
        [JwtAuthorize]
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

        [JwtAuthorize]
        [HttpPut("UpdateById/{id}")]
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

        [JwtAuthorize]
        [HttpDelete("DeleteById/{id}")]
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
