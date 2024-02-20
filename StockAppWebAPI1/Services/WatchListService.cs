using StockAppWebApi.Models;
using StockAppWebAPI1.Models;
using StockAppWebAPI1.Repository;

namespace StockAppWebAPI1.Services
{
    public class WatchListService : IWatchListService
    {
        private readonly IUserRepository _userRepository;
        private readonly IWatchListRepository _watchListRepository;
        public WatchListService(IWatchListRepository watchListRepository)
        {
            _watchListRepository = watchListRepository;
        }

        public Task AddStockToWatchlist(int userId, int stockId)
        {
            return _watchListRepository.AddStockToWatchlist(userId, stockId);
        }

        public Task<WatchList?> GetWatchlist(int userId, int stockId)
        {
            return _watchListRepository.GetWatchlist(userId, stockId);
        }

        public Task<List<Stock?>?> GetWatchListByUserId(int userId)
        {
            return _watchListRepository.GetWatchListByUserId(userId);
        }
    }
}
