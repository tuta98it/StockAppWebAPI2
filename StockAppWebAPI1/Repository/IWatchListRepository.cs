using StockAppWebApi.Models;
using StockAppWebAPI1.Models;

namespace StockAppWebAPI1.Repository
{
    public interface IWatchListRepository
    {
        Task AddStockToWatchlist(int userId, int stockId);
        Task<WatchList?> GetWatchlist(int userId, int stockId);
        Task<List<Stock?>?> GetWatchListByUserId(int userId);
    }
}
