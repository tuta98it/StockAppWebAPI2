using StockAppWebApi.Models;
using StockAppWebAPI1.Models;

namespace StockAppWebAPI1.Repository
{

    public class WatchListRepository : IWatchListRepository
    {
        private readonly StockAppContext _context;
        private readonly IConfiguration _config;
        public WatchListRepository(StockAppContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public Task AddStockToWatchlist(int userId, int stockId)
        {
            throw new NotImplementedException();
        }

        public Task<WatchList?> GetWatchlist(int userId, int stockId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Stock?>?> GetWatchListByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
