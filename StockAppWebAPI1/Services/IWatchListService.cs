using StockAppWebAPI11.Models;

namespace StockAppWebAPI11.Services
{
    public interface IWatchListService
    {
        Task AddStockToWatchlist(int userId, int stockId);
        Task<WatchList?> GetWatchlist(int userId, int stockId);
        Task<List<Stock?>?> GetWatchListByUserId(int userId);
    }
}
