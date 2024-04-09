using StockAppWebAPI11.Models;
using StockAppWebAPI11.Repository;

namespace StockAppWebAPI11.Services
{
    public class WatchListService : IWatchListService
    {
        private readonly IWatchListRepository _watchListRepository;
        public WatchListService(IWatchListRepository watchListRepository)
        {
            _watchListRepository = watchListRepository;
        }

        public async Task AddStockToWatchlist(int userId, int stockId)
        {
            await _watchListRepository.AddStockToWatchlist(userId, stockId);
        }

        public async Task<WatchList?> GetWatchlist(int userId, int stockId)
        {
            return await _watchListRepository.GetWatchlist(userId, stockId);
        }

        public async Task<List<Stock?>?> GetWatchListByUserId(int userId)
        {
            return await _watchListRepository.GetWatchListByUserId(userId);
        }
    }
}
