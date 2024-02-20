using Microsoft.AspNetCore.Mvc;
using StockAppWebApi.Models;
using StockAppWebAPI1.Attributes;
using StockAppWebAPI1.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace StockAppWebAPI1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WatchListController : ControllerBase
    {
        private readonly WatchListController _watchListController;
        public WatchListController(WatchListController watchListController)
        {
            _watchListController = watchListController;
        }

        [JwtAuthorize]
        public Task AddStockToWatchlist(int userId, int stockId)
        {
            return _watchListController.AddStockToWatchlist(userId, stockId);
        }

        [JwtAuthorize]
        public Task<WatchList?> GetWatchlist(int userId, int stockId)
        {
            return _watchListController.GetWatchlist(userId, stockId);
        }

        [JwtAuthorize]
        public Task<List<Stock?>?> GetWatchListByUserId(int userId)
        {
            return _watchListController.GetWatchListByUserId(userId);
        }
    }
}
