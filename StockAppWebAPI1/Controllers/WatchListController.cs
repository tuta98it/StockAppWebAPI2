using Microsoft.AspNetCore.Mvc;
using StockAppWebAPI1.Extensions;
using StockAppWebAPI11.Attributes;
using StockAppWebAPI11.Services;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace StockAppWebAPI11.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WatchListController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWatchListService _watchListService;
        private readonly IStockService _stockService;
        public WatchListController(
            IUserService userService,
            IWatchListService watchListService,
            IStockService stockService
            )
        {
            _userService = userService;
            _watchListService = watchListService;
            _stockService = stockService;
        }

        [HttpGet]
        [JwtAuthorize]
        public async Task<IActionResult> GetMyWatchList(int stockId)
        {
            // Lấy UserId từ context
            int userId = HttpContext.GetUserId();
            // Kiểm tra người dùng và cổ phiếu tồn tại
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }
            var stocks = await _watchListService.GetWatchListByUserId(userId);
            return Ok(stocks);
        }

        [HttpPost("AddStockToWatchlist/{stockId}")]
        [JwtAuthorize]
        public async Task<IActionResult> AddStockToWatchlist(int stockId)
        {
            // Lấy UserId từ context
            int userId = HttpContext.GetUserId();

            // Kiểm tra người dùng và cổ phiếu tồn tại
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var stock = await _stockService.GetStockById(stockId);
            if (stock == null)
            {
                return NotFound("Stock not found.");
            }

            var existingWatchlistItem = await _watchListService.GetWatchlist(userId, stockId);
            if (existingWatchlistItem != null)
            {
                return BadRequest("Stock is already in watchlist.");
            }
            await _watchListService.AddStockToWatchlist(userId, stockId);
            return Ok();
        }
    }
}
